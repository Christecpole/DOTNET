using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice5Abo
{
    public sealed class SubscriptionService
    {
        public const decimal MonthlyPrice = 9.99m;
        public const decimal YearlyPrice = 99.00m;

        private readonly ISubscriptionRepository _repository;
        private readonly IPaymentGateway _paymentGateway;
        private readonly IEmailSender _emailSender;

        public SubscriptionService(
            ISubscriptionRepository repository,
            IPaymentGateway paymentGateway,
            IEmailSender emailSender)
        {
            _repository = repository;
            _paymentGateway = paymentGateway;
            _emailSender = emailSender;
        }

        public void Subscribe(Guid userId, string email, PlanType plan)
        {
            if (userId == Guid.Empty)
                throw new SubscriptionDomainException("UserId is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new SubscriptionDomainException("Email is required.");

            var existing = _repository.GetByUserId(userId);
            if (existing is not null && existing.IsActive)
                throw new SubscriptionDomainException("Subscription already active.");

            var amount = GetPrice(plan);

            var paid = _paymentGateway.Charge(userId, amount);
            if (!paid)
                throw new SubscriptionDomainException("Payment refused.");

            var subscription = new Subscription
            {
                UserId = userId,
                Plan = plan,
                IsActive = true
            };

            _repository.Save(subscription);
            _emailSender.Send(email, "Subscription confirmed.");
        }

        public void ChangePlan(Guid userId, PlanType newPlan)
        {
            if (userId == Guid.Empty)
                throw new SubscriptionDomainException("UserId is required.");

            var subscription = _repository.GetByUserId(userId);
            if (subscription is null || !subscription.IsActive)
                throw new SubscriptionDomainException("No active subscription.");

            if (subscription.Plan == newPlan)
                return;

            if (subscription.Plan == PlanType.Monthly && newPlan == PlanType.Yearly)
            {
                var paid = _paymentGateway.Charge(userId, YearlyPrice);
                if (!paid)
                    throw new SubscriptionDomainException("Payment refused.");
            }

            subscription.Plan = newPlan;
            _repository.Save(subscription);
        }

        public void Cancel(Guid userId, string email)
        {
            if (userId == Guid.Empty)
                throw new SubscriptionDomainException("UserId is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new SubscriptionDomainException("Email is required.");

            var subscription = _repository.GetByUserId(userId);
            if (subscription is null)
                throw new SubscriptionDomainException("No subscription found.");

            subscription.IsActive = false;
            _repository.Save(subscription);
            _emailSender.Send(email, "Subscription cancelled.");
        }

        private static decimal GetPrice(PlanType plan) => plan switch
        {
            PlanType.Monthly => MonthlyPrice,
            PlanType.Yearly => YearlyPrice,
            _ => throw new SubscriptionDomainException("Unknown plan.")
        };
    }
}

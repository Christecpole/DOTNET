using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice5Abo
{

    public interface IPaymentGateway
    {
        bool Charge(Guid userId, decimal amount);
    }

    public interface ISubscriptionRepository
    {
        Subscription? GetByUserId(Guid userId);
        void Save(Subscription subscription);
    }

    public interface IEmailSender
    {
        void Send(string email, string message);
    }
}

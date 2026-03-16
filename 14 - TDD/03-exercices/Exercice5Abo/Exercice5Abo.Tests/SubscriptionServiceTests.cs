using Castle.Core.Smtp;
using Moq;

namespace Exercice5Abo.Tests;

[TestClass]
public class SubscriptionServiceTests
{
    private Guid _userId;
    private string _email;

    [TestInitialize]
    public void Setup()
    {
        _userId = Guid.NewGuid();
        _email = "user@test.com";
    }

    [TestMethod]
    public void Subscribe_WhenPaymentOk_ShouldSaveAndSendEmail()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns((Subscription?)null);

        Mock.Get(payment)
            .Setup(p => p.Charge(_userId, 9.99m))
            .Returns(true);

        var service = new SubscriptionService(repo, payment, mail);

        service.Subscribe(_userId, _email, PlanType.Monthly);

        Mock.Get(repo).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
        Mock.Get(mail).Verify(m => m.Send(_email, It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    public void Subscribe_WhenPaymentFails_ShouldThrow_AndNotSave_AndNotSendEmail()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns((Subscription?)null);

        Mock.Get(payment)
            .Setup(p => p.Charge(_userId, It.IsAny<decimal>()))
            .Returns(false);

        var service = new SubscriptionService(repo, payment, mail);

        Assert.Throws<SubscriptionDomainException>(() =>
            service.Subscribe(_userId, _email, PlanType.Monthly));

        Mock.Get(repo).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Never);
        Mock.Get(mail).Verify(m => m.Send(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [TestMethod]
    public void Subscribe_WhenAlreadyActive_ShouldThrow()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });

        var service = new SubscriptionService(repo, payment, mail);

        Assert.Throws<SubscriptionDomainException>(() =>
            service.Subscribe(_userId, _email, PlanType.Monthly));
    }

    [TestMethod]
    public void Subscribe_WhenUserIdEmpty_ShouldThrow()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        var service = new SubscriptionService(repo, payment, mail);

        Assert.Throws<SubscriptionDomainException>(() =>
            service.Subscribe(Guid.Empty, _email, PlanType.Monthly));
    }

    [TestMethod]
    public void Subscribe_WhenEmailInvalid_ShouldThrow()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        var service = new SubscriptionService(repo, payment, mail);

        Assert.Throws<SubscriptionDomainException>(() =>
            service.Subscribe(_userId, "   ", PlanType.Monthly));
    }

    [TestMethod]
    public void Cancel_WhenSubscriptionExists_ShouldDeactivate_Save_AndSendEmail()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });

        var service = new SubscriptionService(repo, payment, mail);

        service.Cancel(_userId, _email);

        Mock.Get(repo).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
        Mock.Get(mail).Verify(m => m.Send(_email, It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    public void Cancel_WhenNoSubscription_ShouldThrow()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns((Subscription?)null);

        var service = new SubscriptionService(repo, payment, mail);

        Assert.Throws<SubscriptionDomainException>(() =>
            service.Cancel(_userId, _email));
    }

    [TestMethod]
    public void ChangePlan_WhenNewPlanIsDifferent_ShouldSave()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });

        Mock.Get(payment)
            .Setup(p => p.Charge(_userId, It.IsAny<decimal>()))
            .Returns(true);

        var service = new SubscriptionService(repo, payment, mail);

        service.ChangePlan(_userId, PlanType.Yearly);

        Mock.Get(repo).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
    }

    [TestMethod]
    public void ChangePlan_WhenSamePlan_ShouldDoNothing()
    {
        var repo = Mock.Of<ISubscriptionRepository>();
        var payment = Mock.Of<IPaymentGateway>();
        var mail = Mock.Of<IEmailSender>();

        Mock.Get(repo)
            .Setup(r => r.GetByUserId(_userId))
            .Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });

        var service = new SubscriptionService(repo, payment, mail);

        service.ChangePlan(_userId, PlanType.Monthly);

        Mock.Get(repo).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Never);
        Mock.Get(payment).Verify(p => p.Charge(It.IsAny<Guid>(), It.IsAny<decimal>()), Times.Never);
    }
}

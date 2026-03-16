using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice5Abo
{
    public sealed class SubscriptionDomainException : Exception
    {
        public SubscriptionDomainException(string message) : base(message)
        {
        }
    }
}

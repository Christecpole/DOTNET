using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice5Abo
{
    public class Subscription
    {
        public Guid UserId { get; set; }
        public PlanType Plan { get; set; }
        public bool IsActive { get; set; }
    }
}

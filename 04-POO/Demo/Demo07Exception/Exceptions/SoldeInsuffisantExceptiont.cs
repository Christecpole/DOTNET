using System;
using System.Collections.Generic;
using System.Text;

namespace Demo07Exception.Exceptions
{
    internal class SoldeInsuffisantExceptiont: Exception
    {
        public SoldeInsuffisantExceptiont(string message) : base(message) { }
    }
}

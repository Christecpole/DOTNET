using System;
using System.Collections.Generic;
using System.Text;

namespace Demo07Exception.Exceptions
{
    internal class MontantNegatifException : Exception
    {
        public MontantNegatifException(string message) : base(message) { }
    }
}

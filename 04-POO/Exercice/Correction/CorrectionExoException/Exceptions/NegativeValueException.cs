using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoException.Exceptions
{
    internal class NegativeValueException : Exception
    {
        public NegativeValueException(string? message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoException.Exceptions
{
    internal class InvalideAgeException : Exception
    {
        public InvalideAgeException()
        {
        }

        public InvalideAgeException(string? message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2
{
    internal class UpperCaseDecorator : TextDecorator
    {
        public UpperCaseDecorator(IText inner) : base(inner)
        {
        }

        public override string Transform(string input)
        {
            return base.Transform(input).ToUpperInvariant();
        }
    }
}

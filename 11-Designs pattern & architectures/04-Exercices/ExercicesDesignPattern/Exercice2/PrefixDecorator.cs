using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2
{
    internal class PrefixDecorator : TextDecorator
    {
        private readonly string _prefix;

        public PrefixDecorator(IText inner, string prefix) : base(inner) { 
         _prefix = prefix;
        }

        public override string Transform(string input)
        {
            return _prefix + base.Transform(input);
        }
    }
}

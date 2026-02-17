using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2
{
    internal abstract class TextDecorator : IText
    {
        protected readonly IText Inner;

        protected TextDecorator(IText inner)
        {
            Inner = inner; 
        }

        public virtual string Transform(string text) => Inner.Transform(text);
    }
}

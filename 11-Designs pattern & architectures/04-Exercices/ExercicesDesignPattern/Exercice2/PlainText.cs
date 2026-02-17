using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2
{
    internal class PlainText : IText
    {
        public string Transform(string text)
        {
            return text;
        }
    }
}

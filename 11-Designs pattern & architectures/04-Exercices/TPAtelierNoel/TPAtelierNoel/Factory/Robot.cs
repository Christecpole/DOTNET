using System;
using System.Collections.Generic;
using System.Text;

namespace TPAtelierNoel.Factory
{
    internal class Robot : IJouet
    {
        public string GetDescription()
        {
            return "Un Robot Terminator !!!!";
        }
    }
}

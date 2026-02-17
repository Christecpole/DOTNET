using System;
using System.Collections.Generic;
using System.Text;

namespace TPAtelierNoel.Factory
{
    internal class GameBoy : IJouet
    {
        public string GetDescription()
        {
            return "Une Game Boy !!!!";
        }
    }
}

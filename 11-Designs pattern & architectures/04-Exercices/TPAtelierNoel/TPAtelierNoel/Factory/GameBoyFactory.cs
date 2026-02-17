using System;
using System.Collections.Generic;
using System.Text;

namespace TPAtelierNoel.Factory
{
    internal class GameBoyFactory : JouetFactory
    {
        public override IJouet CreerJouet()
        {
            return new GameBoy();
        }
    }
}

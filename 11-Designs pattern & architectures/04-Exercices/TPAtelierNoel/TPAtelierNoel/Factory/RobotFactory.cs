using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TPAtelierNoel.Factory
{
    internal class RobotFactory : JouetFactory
    {
        public override IJouet CreerJouet()
        {
            return new Robot();
        }
    }
}

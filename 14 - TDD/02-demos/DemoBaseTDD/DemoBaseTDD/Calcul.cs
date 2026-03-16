using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBaseTDD
{
    public class Calcul
    {

        public double Addition(double x, double y)
        {
            return x + y;
        }

        public double Division(double x, double y)
        {
            if(y != 0)
                return x / y;

            throw new DivideByZeroException("Division par 0 impossible");
           
        }
    }
}

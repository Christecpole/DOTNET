using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace DemoPolymorphisme.Classes
{
    internal class Additioneur
    {

        public static int Addition (int a, int b)
        {
            return a + b;
        }

        public static double Addition (double a, double b)
        {
            return a + b; 
        }

        public static String Addition(String a, String b)
        {
            int A = int.Parse(a);
            int B = int.Parse(b);

            int result = A + B;

            return result.ToString();
        }
    }
}

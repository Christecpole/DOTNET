using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBaseTDD
{
    
    public class NumbersPack
    {

        private readonly Int128 _count;

        public NumbersPack(int count)
        {
            _count = count; 
        }

        //Retourne une liste [0,1,2,...,count-1]
        public List<int> GetNumbers()
        {

            var results = new List<int>();

            if (_count < 0) {
                return results;
            }

            for(int i = 0; i < _count; i++)
            {
                results.Add(i);
            }

            return results;
        }
    }
}

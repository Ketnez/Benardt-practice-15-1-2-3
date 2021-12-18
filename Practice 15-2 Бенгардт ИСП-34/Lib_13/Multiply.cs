using LibMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_13
{
    public static class Multiply
    {
        public static string MultiplicationOfMas(this ThisArray Thisarray)
        {
            int multiplication = 1;

            for (int i = 0; i < Thisarray.Length; i++)
            {
                if (Thisarray[i] > 2)
                    multiplication *= Thisarray[i];
            }
            return multiplication.ToString();
        }
    }
}

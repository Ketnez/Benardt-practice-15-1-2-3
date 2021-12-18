using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Lib13
{
    public class Practice
    {

        public static (string, string) CalculatingNumbers()
        {
            Random random = new Random();
            int pastValue = -6;
            int value = random.Next(-5, 5);


            string numbers = string.Empty;
            string results = string.Empty;

            double x = 0;
            while (pastValue != value)
            {
                if (value > 0)
                {
                    x = Math.Sqrt(value);

                }
                if (value < 0)
                {
                    x = value * value;

                }
                numbers += value + ",";
                results += x + ",";



                pastValue = value;
                value = random.Next(-5, 5);


            }
            return (numbers, results);

        }

    }
}


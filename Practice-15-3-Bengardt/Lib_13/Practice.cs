using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_13
{
    public class Practice
    {
        public static void MaximumValueMatrix(int[,] matrix, out string result)
        {
            List<int> element = new List<int>();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int increment = 1;
                int diminution = 1;
                for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                {
                    if (matrix[j, i] < matrix[j + 1, i])
                    {
                        increment++;
                    }
                    if (matrix[j, i] > matrix[j + 1, i])
                    {
                        diminution++;
                    }
                }
                if (diminution == matrix.GetLength(0))
                {
                    element.Add(matrix[matrix.GetLength(0) - 1, i]);
                }
                if (increment == matrix.GetLength(0))
                {
                    element.Add(matrix[0, i]);
                }
            }
            if (element.Count == 0)
            {
                result = "0";
            }
            else
            {
                result = element.Max().ToString();
            }
        }
    }
}

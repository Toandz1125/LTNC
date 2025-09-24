using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class MaxMin
    {
        public static int FindMax(int[,] M, int rows, int cols)
        {
            int max = M[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (M[i, j] > max)
                        max = M[i, j];
                }
            }
            return max;
        }

        public static int FindMin(int[,] M, int rows, int cols)
        {
            int min = M[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (M[i, j] < min)
                        min = M[i, j];
                }
            }
            return min;
        }
    }
}

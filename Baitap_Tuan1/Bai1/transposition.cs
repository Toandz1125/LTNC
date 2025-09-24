using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Transposition
    {
        public static int[,] TranspositonMatrix(int[,] A, int rows, int cols)
        {
            int[,] T = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    T[j, i] = A[i, j];
                }
            }
            return T;
        }
    }
}

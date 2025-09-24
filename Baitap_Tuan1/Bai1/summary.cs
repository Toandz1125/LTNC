using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class Summary
    {
        public static int[,] SumMatrix(int[,] A, int[,] B, int rows, int cols)
        {
            int[,] C = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Multiply
    {
        public static int[,] MultipleMatrix(int[,] A, int[,] B, int rowsA, int colsA, int colsB)
        {
            int[,] C = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    C[i, j] = sum;
                }
            }
            return C;
        }
    }
}

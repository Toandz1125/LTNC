using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Determinant
    {
        public static int CalculateDeterminant(int[,] A, int n)
        {
            if (n == 1)
                return A[0, 0];

            if (n == 2)
                return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];

            int det = 0;
            int sign = 1;

            for (int col = 0; col < n; col++)
            {
                int[,] minor = LayMinor(A, n, 0, col);
                det += sign * A[0, col] * CalculateDeterminant(minor, n - 1);
                sign = -sign;
            }
            return det;
        }

        private static int[,] LayMinor(int[,] A, int n, int rowToRemove, int colToRemove)
        {
            int[,] minor = new int[n - 1, n - 1];
            int r = 0, c = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == rowToRemove) continue;
                c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == colToRemove) continue;
                    minor[r, c] = A[i, j];
                    c++;
                }
                r++;
            }
            return minor;
        }
    }
}

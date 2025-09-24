using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Symmetry
    {
        public static bool SymmetryTest(int[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (A[i, j] != A[j, i])
                        return false;
                }
            }
            return true;
        }
    }
}

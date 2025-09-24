using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class Matrix
    {

        public static void InputMatrix(int[,] M, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("Input element [" + (i) + "," + (j) + "]: ");
                    M[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public static void OutputMatrix(int[,] M, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
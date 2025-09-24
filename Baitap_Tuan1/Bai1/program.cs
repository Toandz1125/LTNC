using System;

namespace Matrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows and columns of matrix A:");
            int rowsA = int.Parse(Console.ReadLine());
            int colsA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of rows and columns of matrix B:");
            int rowsB = int.Parse(Console.ReadLine());
            int colsB = int.Parse(Console.ReadLine());

            int[,] A = new int[rowsA, colsA];
            int[,] B = new int[rowsB, colsB];

            Console.WriteLine("Input matrix A:");
            Matrix.InputMatrix(A, rowsA, colsA);

            Console.WriteLine("Input matrix B:");
            Matrix.InputMatrix(B, rowsB, colsB);

            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Action selection (+,*,show,transposition,maxmin,determinant,symmetry): ");
                string Choice = Console.ReadLine();
                if (Choice == "+")
                {
                    if (colsA != colsB || rowsA != rowsB)
                    {
                        Console.WriteLine("Cannot add two matrices of different sizes");
                        continue;
                    }
                    int[,] C = Summary.SumMatrix(A, B, rowsA, colsB);
                    Console.WriteLine("Result of A + B:");
                    Matrix.OutputMatrix(C, rowsA, colsB);
                }
                else if (Choice == "*")
                {
                    if (colsA != rowsB)
                    {
                        Console.WriteLine("Cannot multiply two matrices! (The col number of A must be equal to the row number of B)");
                        continue;
                    }
                    int[,] C = Multiply.MultipleMatrix(A, B, rowsA, colsA, colsB);
                    Console.WriteLine("Result of A x B:");
                    Matrix.OutputMatrix(C, rowsA, colsB);
                }
                else if (Choice == "show")
                {
                    Console.WriteLine("Matrix A:");
                    Matrix.OutputMatrix(A, rowsA, colsA);
                    Console.WriteLine("Matrix B:");
                    Matrix.OutputMatrix(B, rowsB, colsB);
                }
                else if (Choice == "transposition")
                {
                    Console.WriteLine("Transposition of matrix A:");
                    int[,] At = Transposition.TranspositonMatrix(A, rowsA, colsA);
                    Matrix.OutputMatrix(At, colsA, rowsA);
                    Console.WriteLine("Transpositon of matrix B:");
                    int[,] Bt = Transposition.TranspositonMatrix(B, rowsB, colsB);
                    Matrix.OutputMatrix(Bt, colsB, rowsB);
                }
                else if (Choice == "maxmin")
                {
                    Console.WriteLine("Max and Min of matrix A:");
                    int maxA = MaxMin.FindMax(A, rowsA, colsA);
                    int minA = MaxMin.FindMin(A, rowsA, colsA);
                    Console.WriteLine("Max: " + maxA);
                    Console.WriteLine("Min: " + minA);
                    Console.WriteLine("Max and Min of matrix B:");
                    int maxB = MaxMin.FindMax(B, rowsB, colsB);
                    int minB = MaxMin.FindMin(B, rowsB, colsB);
                    Console.WriteLine("Max: " + maxB);
                    Console.WriteLine("Min: " + minB);
                }
                else if (Choice == "determinant")
                {
                    Console.WriteLine("Determinant of matrix A:");
                    if (rowsA != colsA)
                    {
                        Console.WriteLine("Can't calculate determinant. Matrix A is not a square matrix.");
                    }
                    else
                    {
                        int detA = Determinant.CalculateDeterminant(A, rowsA);
                        Console.WriteLine("Determinant A: " + detA);
                    }
                    Console.WriteLine("Determinant of matrix B:");
                    if (rowsB != colsB)
                    {
                        Console.WriteLine("Can't calculate determinant. Matrix B is not a square matrix.");
                    }
                    else
                    {
                        int detB = Determinant.CalculateDeterminant(B, rowsB);
                        Console.WriteLine("Determinant B: " + detB);
                    }
                }
                else if (Choice == "symmetry")
                {
                    Console.WriteLine("Check the symmetry of matrix a:");
                    bool Symmetrical = Symmetry.SymmetryTest(A, colsA);
                    if (Symmetrical)
                        Console.WriteLine("Matrix A is a symmetric matrix.");
                    else
                        Console.WriteLine("Matrix A is NOT a symmetric matrix.");
                    Console.WriteLine("Check the symmetry of matrix b:");
                    Symmetrical = Symmetry.SymmetryTest(B, colsB);
                    if (Symmetrical)
                        Console.WriteLine("Matrix B is a symmetric matrix..");
                    else
                        Console.WriteLine("Matrix B is NOT a symmetric matrix.");
                }
                else
                {
                    Console.WriteLine("Can't implement. ");
                    Console.ReadLine();
                    break;
                }
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task967();
            Task993();
            Task913();
            Task974();
        }
        /// <summary>
        /// 967.Фирма имеет 10 магазинов. 
        ///Информация о доходе каждого магазина за каждый месяц года хранится в Двумерном массиве (первого магазина — в первой строке, второго — во второй и т. д.). 
        ///Составить программу для расчета среднемесячного дохода любого магазина.
        /// </summary>
        static void Task967()
        {
            int[,] incomeData = new int[10, 12]; 
            Random random = new Random();
            for (int store = 0; store < 10; store++)
            {
                for (int month = 0; month < 12; month++)
                {
                    incomeData[store, month] = random.Next(10000, 50000); 
                }
            }
            Console.Write("Введите номер магазина (от 1 до 10): ");
            int storeNumber;
            if (int.TryParse(Console.ReadLine(), out storeNumber) && storeNumber >= 1 && storeNumber <= 10)
            {
                double averageIncome = CalculateAverageMonthlyIncome(incomeData, storeNumber - 1);
                Console.WriteLine($"Среднемесячный доход магазина {storeNumber}: {averageIncome}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод номера магазина.");
            }
            Console.ReadLine();
        }

        static double CalculateAverageMonthlyIncome(int[,] incomeData, int storeIndex)
        {
            int totalIncome = 0;
            int numberOfMonths = incomeData.GetLength(1); 
            for (int month = 0; month < numberOfMonths; month++)
            {
                totalIncome += incomeData[storeIndex, month];
            }
            double averageIncome = (double)totalIncome / numberOfMonths;
            return averageIncome;
        }
        /// <summary>
        /// 993. Дана целочисленная квадратная матрица.
        /// Найти в каждой строке наибольший элемент и поменять его местами с элементом главной диагонали.
        /// </summary>
        static void Task993()
        {
            Console.Write("Введите размерность квадратной матрицы n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int[,] matrix = new int[n, n];
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = random.Next(1, 101); 
                    }
                }

                Console.WriteLine("Исходная матрица:");
                PrintMatrix(matrix);

                ReplaceMaxWithDiagonal(matrix);

                Console.WriteLine("Матрица после замены:");
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Некорректный ввод размерности матрицы.");
            }
            Console.ReadLine();
        }

        static void ReplaceMaxWithDiagonal(int[,] matrix)
        {
            int n = matrix.GetLength(0); 
            for (int i = 0; i < n; i++)
            {
                int maxRowIndex = i; 
                int maxColIndex = i; 
                int maxElement = matrix[i, i]; 
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxColIndex = j;
                    }
                }
                if (maxColIndex != i)
                {
                    int temp = matrix[i, i];
                    matrix[i, i] = maxElement;
                    matrix[i, maxColIndex] = temp;
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0); 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 913.В Двумерном массиве вещественных чисел найти номер строки, для которой среднеарифметическое значение ее элементов минимально.
        /// </summary>
        static void Task913()
        {
            Console.Write("Введите количество строк в массиве: ");
            if (int.TryParse(Console.ReadLine(), out int rows) && rows > 0)
            {
                Console.Write("Введите количество столбцов в массиве: ");
                if (int.TryParse(Console.ReadLine(), out int cols) && cols > 0)
                {
                    double[,] matrix = new double[rows, cols];
                    Random random = new Random();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix[i, j] = random.NextDouble() * 100; 
                        }
                    }

                    Console.WriteLine("Исходный массив:");
                    PrintMatrix(matrix);

                    int minAvgRow = FindRowWithMinAverage(matrix);

                    Console.WriteLine($"Номер строки с минимальным средним арифметическим: {minAvgRow}");
                }
                else
                {
                    Console.WriteLine("Некорректное количество столбцов.");
                }
            }
            else
            {
                Console.WriteLine("Некорректное количество строк.");
            }
            Console.ReadLine();
        }

        static int FindRowWithMinAverage(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double minAvg = double.MaxValue;
            int minAvgRow = -1;
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;

                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }

                double avg = sum / cols;

                if (avg < minAvg)
                {
                    minAvg = avg;
                    minAvgRow = i;
                }
            }
            return minAvgRow;
        }

        static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j].ToString("F2") + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// 974.Дано вещественное число x. Получить квадратную матрицу порядка n + 1.
        /// </summary>
        static void Task974()
        {
            Console.Write("Введите вещественное число x: ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                Console.Write("Введите порядок матрицы n: ");
                if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
                {
                    double[,] matrix = GenerateMatrix(x, n);
                    Matrix(matrix);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод порядка матрицы.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод вещественного числа.");
            }
            Console.ReadLine();
        }

        static double[,] GenerateMatrix(double x, int n)
        {
            int size = n + 1;
            double[,] matrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j < i)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = Math.Pow(x, j - i);
                    }
                }
            }

            return matrix;
        }

        static void Matrix(double[,] matrix)
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j].ToString("F2") + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

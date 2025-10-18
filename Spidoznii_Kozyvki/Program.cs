using System;

namespace NonPositiveColumns
{
    class Program
    {
        // Процедура: проверяет, содержит ли столбец ТОЛЬКО неположительные элементы (<= 0)
        static bool IsColumnNonPositive(double[] column)
        {
            foreach (double value in column)
            {
                if (value > 0)
                    return false;
            }
            return true;
        }

        // Подсчёт количества столбцов с неположительными элементами в матрице 10x10
        static int CountNonPositiveColumns(double[,] matrix)
        {
            const int SIZE = 10;
            int count = 0;
            for (int j = 0; j < SIZE; j++)
            {
                double[] column = new double[SIZE];
                for (int i = 0; i < SIZE; i++)
                {
                    column[i] = matrix[i, j];
                }

                if (IsColumnNonPositive(column))
                {
                    count++;
                }
            }
            return count;
        }

        // Вывод матрицы 10x10 на экран
        static void PrintMatrix(double[,] matrix, string name)
        {
            Console.WriteLine($"\nМатрица {name} (10x10):");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{matrix[i, j],8:F2} ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            const int SIZE = 10;

            // Создание и заполнение двух матриц 10x10
            double[,] matrixA = new double[SIZE, SIZE];
            double[,] matrixB = new double[SIZE, SIZE];

            // Диапазон: от -20 до 5 → разница = 25
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    matrixA[i, j] = -20 + rand.NextDouble() * 25;
                    matrixB[i, j] = -20 + rand.NextDouble() * 25;
                }
            }

            // Вывод матриц
            PrintMatrix(matrixA, "A");
            PrintMatrix(matrixB, "B");

            // Подсчёт подходящих столбцов
            int countA = CountNonPositiveColumns(matrixA);
            int countB = CountNonPositiveColumns(matrixB);

            // Вывод результатов
            Console.WriteLine("\n=== РЕЗУЛЬТАТЫ ===");
            if (countA > 0)
                Console.WriteLine($"В матрице A: {countA} столбец(ов) содержат только неположительные элементы.");
            else
                Console.WriteLine("В матрице A нет столбцов, содержащих только неположительные элементы.");

            if (countB > 0)
                Console.WriteLine($"В матрице B: {countB} столбец(ов) содержат только неположительные элементы.");
            else
                Console.WriteLine("В матрице B нет столбцов, содержащих только неположительные элементы.");

            if (countA == 0 && countB == 0)
            {
                Console.WriteLine("\n❗ Ни в одной из матриц нет столбцов с только неположительными элементами.");
            }

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
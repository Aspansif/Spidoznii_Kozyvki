using NUnit.Framework;
using System;

namespace NonPositiveColumns.Tests
{
    [TestFixture]
    public class ProgramNUnitTests
    {
        [Test]
        public void Test1_AllPositiveColumns_ReturnsZero()
        {
            // Arrange
            double[,] matrix = new double[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    matrix[i, j] = 1.5; // Все положительные

            // Act
            int result = Program.CountNonPositiveColumns(matrix);

            // Assert
            Assert.That(result, Is.EqualTo(0), "Все столбцы положительные - должен вернуть 0");
        }

        [Test]
        public void Test2_AllNonPositiveColumns_ReturnsTen()
        {
            // Arrange
            double[,] matrix = new double[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    matrix[i, j] = -2.5; // Все отрицательные

            // Act
            int result = Program.CountNonPositiveColumns(matrix);

            // Assert
            Assert.That(result, Is.EqualTo(10), "Все столбцы отрицательные - должен вернуть 10");
        }

        [Test]
        public void Test3_MixedColumns_ReturnsThree()
        {
            // Arrange
            double[,] matrix = new double[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Столбцы 1, 4, 7 неположительные
                    matrix[i, j] = (j == 1 || j == 4 || j == 7) ? -1.0 : 1.0;
                }
            }

            // Act
            int result = Program.CountNonPositiveColumns(matrix);

            // Assert
            Assert.That(result, Is.EqualTo(3), "3 неположительных столбца - должен вернуть 3");
        }

        [Test]
        public void Test4_WithZeroColumns_ReturnsFour()
        {
            // Arrange
            double[,] matrix = new double[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Столбцы 0, 3, 6, 9 содержат только нули
                    matrix[i, j] = (j == 0 || j == 3 || j == 6 || j == 9) ? 0 : 2.0;
                }
            }

            // Act
            int result = Program.CountNonPositiveColumns(matrix);

            // Assert
            Assert.That(result, Is.EqualTo(4), "4 столбца с нулями - должен вернуть 4");
        }

        [Test]
        public void Test5_SingleNonPositiveColumn_ReturnsOne()
        {
            // Arrange
            double[,] matrix = new double[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Только столбец 5 неположительный
                    matrix[i, j] = (j == 5) ? -3.0 : 1.5;
                }
            }

            // Act
            int result = Program.CountNonPositiveColumns(matrix);

            // Assert
            Assert.That(result, Is.EqualTo(1), "Один неположительный столбец - должен вернуть 1");
        }

        [Test]
        public void Test6_IsColumnNonPositive_WithPositiveElement_ReturnsFalse()
        {
            // Arrange
            double[] column = { -1.5, -2.0, 0.1, 0, -3.7 };

            // Act
            bool result = Program.IsColumnNonPositive(column);

            // Assert
            Assert.That(result, Is.False, "Столбец с положительным элементом должен вернуть False");
        }

        [Test]
        public void Test7_IsColumnNonPositive_AllNonPositive_ReturnsTrue()
        {
            // Arrange
            double[] column = { -1.5, -2.0, -0.5, 0, -3.7 };

            // Act
            bool result = Program.IsColumnNonPositive(column);

            // Assert
            Assert.That(result, Is.True, "Столбец только с неположительными элементами должен вернуть True");
        }

        [Test]
        public void Test8_IsColumnNonPositive_AllZeros_ReturnsTrue()
        {
            // Arrange
            double[] column = { 0, 0, 0, 0, 0 };

            // Act
            bool result = Program.IsColumnNonPositive(column);

            // Assert
            Assert.That(result, Is.True, "Столбец только с нулями должен вернуть True");
        }
    }
}
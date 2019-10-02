using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация двумерного массива и его заполнение
            int colCount = 0, rowCount = 0;
            do
            {
                Console.WriteLine("Write count of rows of matrix: ");
                int.TryParse(Console.ReadLine(), out rowCount);
                if (rowCount <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Count of rows must be less than 100 or equal. Try again");
                }
            } while (true);
            Console.WriteLine();

            do
            {
                Console.WriteLine("Write count of columns of matrix: ");
                int.TryParse(Console.ReadLine(), out colCount);
                if (colCount <= 100)
                {
                    break;
                } else
                {
                    Console.WriteLine("Count of columns must be less than 100 or equal. Try again");
                    Console.WriteLine();
                }
            } while (true);
            Console.WriteLine();

            int[,] twoDimArray = new int[rowCount, colCount];

            Console.WriteLine("Filling this array");
            Console.WriteLine();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Console.WriteLine("[{0}, {1}]:", row + 1, col + 1);
                    int number;
                    do
                    {
                        int.TryParse(Console.ReadLine(), out number);
                        if (number > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Given number must be a natural number");
                            Console.WriteLine();
                        }
                    } while (true);
                    twoDimArray[row, col] = number;
                }
            }
            Console.WriteLine();

            // Преобразование двумерного массива к одномерному
            List<int> oneDimArray = new List<int>();
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    oneDimArray.Add(twoDimArray[row, col]);
                }
            }

            // Обработка одномерного массива по заданию
            int delCount = 0;
            for (int index = 0; index < oneDimArray.Count; index++)
            {
                int number = oneDimArray.ElementAt(index);
                if (number % 10 == 0)
                {
                    oneDimArray.RemoveAt(index);
                    delCount++;
                    index--;
                }
            }
            Console.WriteLine("Array processing done, deleted {0} number(s)", delCount);
            Console.WriteLine();

            Sort(oneDimArray);

            // Вывод результативного массива
            Console.WriteLine("Result:");
            if (oneDimArray.Count > 0)
            {
                foreach (int number in oneDimArray)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            } else
            {
                Console.WriteLine("All numbers were deleted");
            }
            Console.WriteLine();

            Console.WriteLine("Type Enter to exit");
            Console.ReadKey();
        }

        // Используется сортировка вставкой
        static void Sort(List<int> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                int val = array[i];
                int flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = val;
                    }
                    else flag = 1;
                }
            }
            Console.WriteLine("Sorting done");
            Console.WriteLine();
        }
    }
}

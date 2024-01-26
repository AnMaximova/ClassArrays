using System;

class ProgramTwo
{
    class TwoDimensionalArray
    {
        private int[,] arr; //массив
        private float average = 0; //среднее арифметическое

        public TwoDimensionalArray(int row, int column, bool input_mode = false) //возможность заполнения массива пользователем 
        {
            arr = new int[row, column];
            if (input_mode)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write($"Элемент [{i},{j}]: ");
                        arr[i, j] = int.Parse(Console.ReadLine());
                        average += arr[i, j];
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = rnd.Next(-200, 201);
                        average += arr[i, j];
                    }
                }
            }
            average /= (arr.GetLength(0) * arr.GetLength(1));
        }

        public void InputSplit() //ввод элементов массива построчно через пробел
        {
            average = 0;
            Console.WriteLine("Вводите через пробел значения элементов массива по строкам:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"Введите через пробел элементы {i} строки:");
                string text = Console.ReadLine();
                string[] words = text.Split(' ');
                if (words.Length != arr.GetLength(1))
                {
                    if (words.Length < arr.GetLength(1))
                    {
                        Console.WriteLine("Вы ввели меньше элементов, в конце будут нули");
                        for (int j = 0; j < words.Length; j++)
                        {
                            arr[i, j] = int.Parse(words[j]);
                            average += arr[i, j];
                        }
                        for (int j = words.Length; j < arr.GetLength(1); j++)
                        {
                            arr[i, j] = 0;
                        }
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели больше элементов, лишние будут отброшены");
                    }
                }
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = int.Parse(words[j]);
                    average += arr[i, j];
                }
            }
            average /= (arr.GetLength(0) * arr.GetLength(1));
        }

        public void OutArr() // вывод двумерного массива
        {
            Console.WriteLine("Вывод двумерного массива");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.Write("\n");
            }
        }

        public void OutArrEvenReverse() // вывод двумерного массива, четные строки в обратном порядке
        {
            Console.WriteLine("Вывод двумерного массива, четные строки в обратном порядке");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int index = j;
                    if (i % 2 == 0)
                    {
                        index = arr.GetLength(1) - j - 1;

                    }
                    Console.Write($"{arr[i, index]}\t");
                }
                Console.Write("\n");
            }
        }

        public float Average //среднее арифметическое элементов массива
        {
            get
            {
                return average;
            }
        }

        public void Det() 
        {
            if (arr.GetLength(0) != arr.GetLength(1)) 
            {
                Console.WriteLine("Вычислить определитель можно только у квадратной матрицы");
                return;
            }
            else
            {
                double[,] matrix = new double[arr.GetLength(0), arr.GetLength(0)];
                double det = 1;
                // копируем матрицу в тип double для преобразования к треугольной
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        matrix[i, j] = arr[i,j];
                    }

                }
                // приводим матрицу к треугольному виду (алгоритм Гаусса)
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = i + 1; j < matrix.GetLength(0); j++)
                    {
                        double koef = matrix[j, i] / matrix[i, i];
                        for (int k = i; k < matrix.GetLength(0); k++)
                            matrix[j, k] -= matrix[i, k] * koef;
                    }
                }
                // выводим треугольную матрицу, чтобы увидеть, что она треугольная, и считаем определитель
                Console.WriteLine("Треугольная матрица");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        Console.Write("{0:f1}\t", matrix[i,j]); 
                    }
                    Console.WriteLine();
                    det *= matrix[i, i];
                }
                Console.WriteLine("Определитель матрицы равен {0:f0}",det);
            }
        }
    }
    static void Main()
    {
        TwoDimensionalArray one = new TwoDimensionalArray(4, 6);
        one.OutArr();
        one.OutArrEvenReverse();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {one.Average}");
        Console.WriteLine("Заполните двумерный массив самостоятельно (3 строки, два столбца):");
        TwoDimensionalArray two = new TwoDimensionalArray(3, 2, true);
        two.OutArr();
        two.OutArrEvenReverse();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {two.Average}");
        Console.WriteLine("Введите элементы массива через пробел (2 строки, 3 столбца):");
        TwoDimensionalArray three = new TwoDimensionalArray(2,3);
        three.InputSplit();
        three.OutArr();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {three.Average}");
        Console.WriteLine("Вычислим определитель матрицы");
        TwoDimensionalArray four = new TwoDimensionalArray(3, 3);
        four.OutArr();
        four.Det();
    }
}

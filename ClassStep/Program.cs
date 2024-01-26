using System;

class ProgramStep
{
    class StepDimensionalArray
    {
        private int[][] arr; //массив
        private float average = 0; //среднее арифметическое элементов массива
        private float[] average_line; //массив средних арифметических вложенных массивов

        public StepDimensionalArray(int row, bool input_mode = false) //возможность заполнения массива пользователем 
        {
            arr = new int[row][];
            average_line  = new float[row];
            int count = 0;
            if (input_mode)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    average_line[i] = 0;
                    Console.WriteLine($"Введите количество элементов для ступеньки {i}:");
                    int n = int.Parse(Console.ReadLine());
                    arr[i] = new int[n];
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        Console.Write($"Ступенька [{i}], элемент [{j}]: ");
                        arr[i][j] = int.Parse(Console.ReadLine());
                        count++;
                        average += arr[i][j];
                        average_line[i] += arr[i][j];
                    }
                    average_line[i] /= arr[i].Length;
                }
            }
            else
            {
                Random rnd = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    average_line[i] = 0;
                    int n = rnd.Next(1, 11);
                    arr[i] = new int[n];
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i][j] = rnd.Next(-20, 21);
                        count++;
                        average += arr[i][j];
                        average_line[i] += arr[i][j];
                    }
                    average_line[i] /= arr[i].Length;
                }
            }
            average /= count;
        }

        public void InputSplit() //ввод элементов массива построчно через пробел
        {
            average_line = new float[arr.Length];
            average = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Введите через пробел {arr[i].Length} значений(я) для ступеньки {i}:");
                string text = Console.ReadLine();
                string[] words = text.Split(' ');
                arr[i] = new int[words.Length];
                for (int j = 0; j < words.Length; j++)
                {
                    arr[i][j] = int.Parse(words[j]);
                    count++;
                    average += arr[i][j];
                    average_line[i] += arr[i][j];
                }
                average_line[i] /= arr[i].Length;
            }
            average /= count;
        }

        public void OutArr() // вывод ступеньчатого массива
        {
            Console.WriteLine("Вывод ступеньчатого массива");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]}\t");
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

        public void AverageLine() //среднее арифметическое элементов массива по ступенькам
        {
            Console.WriteLine("Среднее арифметическое элементов массива по ступенькам");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Ступенька {i} среднее арифметическое {average_line[i]}");
            }
        }

        public void Change_Even()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] % 2 == 0)
                    {
                        arr[i][j] = i * j;
                    }
                }
            }
        }

    }
    static void Main()
    {
        StepDimensionalArray one = new StepDimensionalArray(4);
        one.OutArr();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {one.Average}");
        one.AverageLine();
        Console.WriteLine("Заменим четные по значению элементы массива на произведения их индексов");
        one.Change_Even();
        one.OutArr();
        Console.WriteLine("Заполните ступеньчатый массив самостоятельно (3 строки):");
        StepDimensionalArray two = new StepDimensionalArray(3,true);
        two.OutArr();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {two.Average}");
        Console.WriteLine("Введите элементы массива через пробел (2 ступеньки):");
        StepDimensionalArray three = new StepDimensionalArray(2);
        three.InputSplit();
        three.OutArr();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {three.Average}");
    }
}

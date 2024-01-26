using System;
using System.Xml.Linq;

class ProgramOne
{
    class OneDimensionalArray
    {
        private int[] arr; //массив
        private float average = 0; //среднее арифметическое

        public OneDimensionalArray(int size, bool input_mode = false) //возможность заполнения массива пользователем 
        {
            arr = new int[size];
            if (input_mode)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write($"Введите {i} элемент массива: ");
                    arr[i] = int.Parse(Console.ReadLine());
                    average += arr[i];
                }
            }
            else
            {
                Random rnd = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rnd.Next(-200, 201);
                    average += arr[i];
                }
            }
            average /= arr.Length;
        }

        public void InputMethod() // публичный метод заполнения массива, удобно использовать при повторном заполнении массива
        {
            Random rnd = new Random();
            average = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10, 11);
                average += arr[i];
            }
            average /= arr.Length;
        }

        public void OutArrColumn() // вывод массива в столбик с номерами элементов
        {
            Console.WriteLine("Вывод массива");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i} элемент массива равен: {arr[i]}");
            }
        }

        public void OutArrLine() // вывод массива в строку
        {
            Console.WriteLine("Вывод массива");
            foreach (int element in arr)
                Console.Write(element.ToString() + "\t");
            Console.WriteLine();
        }

        public float Average //среднее арифметическое элементов массива
        {
            get
            {
                return average;
            }
        }

        public void MoreThan100Abs() //удаление из массива больших чем 100 по модулю элементов
        {
            int num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) <= 100)
                {
                    num++;
                }
            }
            int[] an = new int[num];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) <= 100)
                {
                    an[j] = arr[i];
                    j++;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < an.Length)
                {
                    arr[i] = an[i];
                    Console.Write(arr[i].ToString() + "\t");
                }
                else 
                {
                    arr[i] = 0; 
                }
            }
            Console.WriteLine("\n");
        }

        private void BubbleSort() // сортировка массива, используется для удаления повторяющихся элементов
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        public void DelRep() //удаление повтояющихся элементов массива
        {
            int num = 1;
            BubbleSort();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != arr[i + 1])
                {
                    num++;
                }
            }
            int[] an = new int[num];
            int j = 0;
            an[j] = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] != an[j])
                {
                    j++;
                    an[j] = arr[i];
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < an.Length)
                {
                    arr[i] = an[i];
                    Console.Write(arr[i].ToString() + "\t");
                }
                else
                {
                    arr[i] = 0;
                }  
            }
        }
    }

    static void Main()
    {
        OneDimensionalArray one = new OneDimensionalArray(6);
        one.OutArrColumn();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {one.Average}");
        Console.WriteLine("Из массива удалены все элементы, большие 100 по модулю:");
        one.MoreThan100Abs();
        Console.WriteLine("Заполним снова массив через вызов отдельного публичного метода");
        one.InputMethod();
        one.OutArrLine();
        Console.WriteLine($"Среднее арифметическое элементов массива равно {one.Average}");
        Console.WriteLine("Заполните массив самостоятельно (3 элемента):");
        OneDimensionalArray two = new OneDimensionalArray(3, true);
        two.OutArrLine();
        Console.WriteLine("Заполните массив самостоятельно (10 элементов):");
        OneDimensionalArray three = new OneDimensionalArray(10, true);
        Console.WriteLine("Из массива удалены все повторяющиеся элементы:");
        three.DelRep(); 
    }
}


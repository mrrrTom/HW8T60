// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

namespace HW60
{
    class ConsoleApp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to 3d array generator!");
            Console.WriteLine("Here comes your array:");
            var arr = new MatrixBuilder(2);
            arr.SetRandomValues();
            Console.WriteLine(arr.ToString());
        }
    }

    public class MatrixBuilder
    {
        private double[, ,] _arr;
        private bool _isInitialized = false;
        private Random _rnd;
        private HashSet<double> _values = new HashSet<double>();
        public int Size { get; private set; }

        public MatrixBuilder(int size)
        {
            _arr = new double[size, size, size];
            Size = size;
            _rnd = new Random();
            _isInitialized = true;
        }

        public override string ToString()
        {
            return _arr.ToArrString();
        }

        public void SetRandomValues()
        {
            var rnd = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int l = 0; l < Size; l++)
                    {
                        _arr[i, j, l] = GetNextRandom();
                    }
                }
            }
        }

        private double GetNextRandom()
        {
            var signPow = _rnd.Next(1, 3);
            var tenPow = _rnd.Next(0, 3);
            var doubleValue = _rnd.NextDouble();
            var sign = ((double)Math.Pow(-1, signPow));
            var tens = ((double)Math.Pow(10, tenPow));
            var roundCount = _rnd.Next(0, 3);
            var newValue = Math.Round(doubleValue * sign * tens, roundCount);
            if (_values.Contains(newValue))
            {
                return GetNextRandom();
            }
            else
            {
                _values.Add(newValue);
                return newValue;
            }
        }
    }

    public static class ArrExtension
    {
        public static string ToArrString(this double[, ,] arr)
        {
            var result = string.Empty;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int l = 0; l < arr.GetLength(2); l++)
                    {
                        result += arr[i, j, l] + $"({i}, {j}, {l})" +"\t";
                    }
                }

                result += "\n";
            }

            return result;
        }
    }
}
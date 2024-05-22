namespace Mod12Part1
{
    internal class Task1
    {
        public static void Tas1()
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(rand.Next(1, 1000));
            }

            List<int> primeNumbers = numbers.Where(IsPrime).ToList();
            List<int> fibonacciNumbers = numbers.Where(IsFibonacci).ToList();

            File.WriteAllLines("PrimeNumbers.txt", primeNumbers.Select(n => n.ToString()));

            File.WriteAllLines("FibonacciNumbers.txt", fibonacciNumbers.Select(n => n.ToString()));

            Console.WriteLine("Згенеровано чисел: " + numbers.Count);
            Console.WriteLine("Прості числа: " + primeNumbers.Count);
            Console.WriteLine("Числа Фібоначчі: " + fibonacciNumbers.Count);
            Console.WriteLine("Прості числа збережені у файл PrimeNumbers.txt");
            Console.WriteLine("Числа Фібоначчі збережені у файл FibonacciNumbers.txt");
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static bool IsFibonacci(int number)
        {
            if (number == 0 || number == 1) return true;

            int a = 0;
            int b = 1;
            while (b < number)
            {
                int temp = b;
                b = a + b;
                a = temp;
            }
            return b == number;
        }
    }
}

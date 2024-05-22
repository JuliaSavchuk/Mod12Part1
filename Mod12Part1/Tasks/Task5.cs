namespace Mod12Part1
{
    internal class Task5
    {
        public static void Tas5()
        {
            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();
            List<int> numbers = ReadNumbersFromFile(filePath);

            DisplayStatistics(numbers);

            CreateFiles(numbers);
        }

        static List<int> ReadNumbersFromFile(string filePath)
        {
            List<int> numbers = new List<int>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }

        static void DisplayStatistics(List<int> numbers)
        {
            int positiveCount = 0;
            int negativeCount = 0;
            int twoDigitCount = 0;
            int fiveDigitCount = 0;

            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    positiveCount++;
                }
                else if (number < 0)
                {
                    negativeCount++;
                }

                if (number >= 10 && number <= 99)
                {
                    twoDigitCount++;
                }
                else if (number >= -99999 && number <= -10000)
                {
                    fiveDigitCount++;
                }
            }

            Console.WriteLine($"Кількість додатних чисел: {positiveCount}");
            Console.WriteLine($"Кількість від'ємних чисел: {negativeCount}");
            Console.WriteLine($"Кількість двозначних чисел: {twoDigitCount}");
            Console.WriteLine($"Кількість п'ятизначних чисел: {fiveDigitCount}");
        }

        static void CreateFiles(List<int> numbers)
        {
            List<int> positiveNumbers = new List<int>();
            List<int> negativeNumbers = new List<int>();
            List<int> twoDigitNumbers = new List<int>();
            List<int> fiveDigitNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    positiveNumbers.Add(number);
                }
                else if (number < 0)
                {
                    negativeNumbers.Add(number);
                }

                if (number >= 10 && number <= 99)
                {
                    twoDigitNumbers.Add(number);
                }
                else if (number >= -99999 && number <= -10000)
                {
                    fiveDigitNumbers.Add(number);
                }
            }

            File.WriteAllLines("positiveNumbers.txt", positiveNumbers.ConvertAll(x => x.ToString()));
            File.WriteAllLines("negativeNumbers.txt", negativeNumbers.ConvertAll(x => x.ToString()));
            File.WriteAllLines("twoDigitNumbers.txt", twoDigitNumbers.ConvertAll(x => x.ToString()));
            File.WriteAllLines("fiveDigitNumbers.txt", fiveDigitNumbers.ConvertAll(x => x.ToString()));
        }
    }
}

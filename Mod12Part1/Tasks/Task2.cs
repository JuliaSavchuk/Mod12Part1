namespace Mod12Part1
{
    internal class Task2
    {
        public static void Tas2()

        {
            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            Console.Write("Введіть слово для пошуку: ");
            string searchWord = Console.ReadLine();

            Console.Write("Введіть слово для заміни: ");
            string replaceWord = Console.ReadLine();

            int replacements = ReplaceInFile(filePath, searchWord, replaceWord);

            Console.WriteLine($"Здійснено {replacements} замін(-а/-и) у файлі.");
        }

        static int ReplaceInFile(string filePath, string searchWord, string replaceWord)
        {
            int replacements = 0;

            string content = File.ReadAllText(filePath);

            content = content.Replace(searchWord, replaceWord, StringComparison.CurrentCultureIgnoreCase);

            File.WriteAllText(filePath, content);

            string[] words = content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (string.Equals(word, replaceWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    replacements++;
                }
            }

            return replacements;
        }

    }
}

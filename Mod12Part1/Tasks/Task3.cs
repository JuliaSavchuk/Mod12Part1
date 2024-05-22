namespace Mod12Part1
{
    internal class Task3
    {
        public static void Tas3()
        {
            Console.Write("Введіть шлях до файлу з текстом: ");
            string textFilePath = Console.ReadLine();

            Console.Write("Введіть шлях до файлу зі словами для модерації: ");
            string moderationFilePath = Console.ReadLine();

            int moderatedWordsCount = ModerateText(textFilePath, moderationFilePath);

            Console.WriteLine($"Кількість замінених слів: {moderatedWordsCount}");
        }

        static int ModerateText(string textFilePath, string moderationFilePath)
        {
            int moderatedWordsCount = 0;

            HashSet<string> wordsToModerate = new HashSet<string>(File.ReadAllLines(moderationFilePath));

            string[] lines = File.ReadAllLines(textFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');

                for (int j = 0; j < words.Length; j++)
                {
                    if (wordsToModerate.Contains(words[j]))
                    {
                        words[j] = new string('*', words[j].Length);
                        moderatedWordsCount++;
                    }
                }

                lines[i] = string.Join(" ", words);
            }

            File.WriteAllLines(textFilePath, lines);

            return moderatedWordsCount;
        }
    }
}


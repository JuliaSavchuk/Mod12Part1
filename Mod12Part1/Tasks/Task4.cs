namespace Mod12Part1
{
    internal class Task4
    {
        public static void Tas4()
        {
            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            string content = File.ReadAllText(filePath);

            char[] charArray = content.ToCharArray();
            Array.Reverse(charArray);
            string reversedContent = new string(charArray);

            File.WriteAllText("ReversedFile", reversedContent);

            Console.WriteLine("Файл перевернуто. Перевірте новий файл.");
        }
    }
}

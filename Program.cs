using System.Text.RegularExpressions;

namespace CSharp17._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");

            if (!File.Exists(filePath))
            {
                string defaultText = "Examples of numbers: 1, 2, 3, 4, 5, 12.34, 56,78, 90.12, 34,56, 78.90, 123,45, 67.89, 10,11.";
                File.WriteAllText(filePath, defaultText);
            }

            string text = File.ReadAllText(filePath);

            string patternDot = @"\b\d+\.\d+\b";
            string patternComma = @"\b\d+\,\d+\b";

            Regex regexDot = new Regex(patternDot);
            Regex regexComma = new Regex(patternComma);

            MatchCollection matchesDot = regexDot.Matches(text);
            MatchCollection matchesComma = regexComma.Matches(text);

            List<string> fractionsDot = new List<string>();
            List<string> fractionsComma = new List<string>();

            foreach (Match match in matchesDot)
            {
                fractionsDot.Add(match.Value);
            }

            foreach (Match match in matchesComma)
            {
                fractionsComma.Add(match.Value);
            }

            Console.WriteLine("Fractions with a dot:");
            foreach (string fraction in fractionsDot)
            {
                Console.WriteLine(fraction);
            }

            Console.WriteLine("Fractions with a comma:");
            foreach (string fraction in fractionsComma)
            {
                Console.WriteLine(fraction);
            }
        }
    }
}

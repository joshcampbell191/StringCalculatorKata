using System.Text.RegularExpressions;

namespace Product
{
    public static class CalculatorHelper
    {
        private readonly static string DELIMITER_PATTERN = @"^\/\/(?<delimiter>.*?)(?=-?\d)";

        public static string[] ParseDelimiters(string input)
        {
            var delimiters = new HashSet<string>(["+", ",", "\n"]);

            var match = Regex.Match(input, DELIMITER_PATTERN);
            if (match.Success)
            {
                var delimiter = match.Groups["delimiter"].Value;

                match = Regex.Match(delimiter, @"\[(?<delimiter>[^\]]+)\]");
                if (!match.Success)
                    delimiters.Add(delimiter);

                while (match.Success)
                {
                    delimiter = match.Groups["delimiter"].Value;
                    delimiters.Add(delimiter);
                    match = match.NextMatch();
                }
            }

            return delimiters.ToArray();
        }


        public static int[] ParseNumbers(string input, string[] delimiters)
        {
            var match = Regex.Match(input, DELIMITER_PATTERN);

            if (match.Success)
                input = input.Substring(match.Length);

            if (string.IsNullOrWhiteSpace(input))
                return [0];

            var results = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x <= 1000) // Filter out numbers greater than 1000
                .ToArray();

            // If any of the numbers are negative, throw an exception
            var negatives = results.Where(x => x < 0).ToArray();
            if (negatives.Length > 0)
                throw new InvalidOperationException($"Negatives not allowed ({string.Join(",", negatives)})");

            return results;
        }
    }
}
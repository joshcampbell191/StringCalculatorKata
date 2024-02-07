using System.Text.RegularExpressions;

namespace Product
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            // If the input is empty, return 0
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            // If the input is only a single number, return the number
            if (int.TryParse(numbers, out var result))
            {
                // If the number is negative, throw an exception
                if (result < 0)
                    throw new InvalidOperationException($"Negatives not allowed ({result})");

                // Return the number
                return result;
            }

            // Set the delimiters to the default delimiters
            var delimiters = new HashSet<string>(["+", ",", "\n"]);

            // If the input defines a custom delimiter, add it to the list of delimiters
            var match = Regex.Match(numbers, @"^\/\/(?<delimiter>.*?)-?\d");
            if (match.Success)
            {
                // Remove the delimiter from the input
                numbers = numbers.Substring(match.Length);

                var delimiter = match.Groups["delimiter"].Value;

                // If the delimiter is not enclosed in square brackets, add it to the list of delimiters
                match = Regex.Match(delimiter, @"\[(?<delimiter>[^\]]+)\]");
                if (!match.Success)
                    delimiters.Add(delimiter);

                // If the delimiter is enclosed in square brackets, add each delimiter to the list of delimiters
                while (match.Success)
                {
                    delimiter = match.Groups["delimiter"].Value;
                    delimiters.Add(delimiter);
                    match = match.NextMatch();
                }
            }

            // Sanitize the input by replacing all delimiters with commas
            foreach (var delimiter in delimiters)
                numbers = numbers.Replace(delimiter, ",");

            // Convert the input into numbers and filter out those that are greater than 1000
            var results = numbers.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x <= 1000)
                .ToArray();

            // If any of the numbers are negative, throw an exception
            var negatives = results.Where(x => x < 0).ToArray();
            if (negatives.Length > 0)
                throw new InvalidOperationException($"Negatives not allowed ({string.Join(",", negatives)})");

            // Return the sum of the numbers
            return results.Sum();
        }
    }
}

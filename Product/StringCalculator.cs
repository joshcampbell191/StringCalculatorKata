namespace Product
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var delimiters = CalculatorHelper.ParseDelimiters(numbers);
            var results = CalculatorHelper.ParseNumbers(numbers, delimiters);

            return results.Sum();
        }
    }
}

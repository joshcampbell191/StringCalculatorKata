using Product;

Console.WriteLine("String Calculator");
Console.WriteLine("(type 'exit' to quit)");
while (true)
{
    Console.WriteLine("Input:");
    var input = Console.ReadLine() ?? String.Empty;
    if (input == "exit")
    {
        return;
    } else
    {
        var calculator = new StringCalculator();
        try
        {
            var sum = calculator.Add(input);
            Console.WriteLine($"Sum: {sum}");
        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

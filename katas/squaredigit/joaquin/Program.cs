// See https://aka.ms/new-console-template for more information

int squareDigits(int input) {

    string numbers = input.ToString();
    string result = "";

    foreach (char c in numbers) {
        double squared = Math.Pow(Int32.Parse(c.ToString()),2);
        result += squared.ToString();
    }
    return Int32.Parse(result);
}

Console.WriteLine(squareDigits(5));
Console.WriteLine(squareDigits(123));
Console.WriteLine(squareDigits(9119));
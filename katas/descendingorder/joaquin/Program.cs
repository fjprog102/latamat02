// See https://aka.ms/new-console-template for more information

int orderByDescending (int input) {
    
    string[] stringNumbers = input.ToString().Split();
    int[] numbers = new int[stringNumbers.Length];
    string output = "";

    for (int i=0; i<stringNumbers.Length; i++) {
        numbers[0] = Int32.Parse(stringNumbers[i]);
    }

    Array.Sort(numbers);
    Array.Reverse(numbers);
    
    foreach (int num in numbers) {
        output += num.ToString();
    }
    
    return Int32.Parse(output);

}

Console.WriteLine(orderByDescending(42145));
Console.WriteLine(orderByDescending(145263));
Console.WriteLine(orderByDescending(123456789));


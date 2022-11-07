// See https://aka.ms/new-console-template for more information
Console.WriteLine("Write your text here:");
var input = Console.ReadLine();

Console.WriteLine(vowelCount(input));

string vowelCount(string input) {
    int count = 0;
    char[] vowels = {'a', 'e', 'i', 'o', 'u'};
    
    for (int i = 0; i < input.Length; i++) {

        if (input[i] == ' ') continue;
        if (Char.IsUpper(input[i]) || Char.IsDigit(input[i]) || !char.IsLetterOrDigit(input[i])) {
            i=0;
            count=0;
            Console.WriteLine("Please enter only lower case letters and/or spaces:");
            input = Console.ReadLine();
        };
        if (vowels.Contains(input[i])) count ++;
    }

    return $"The amount of vowels is {count}";

};


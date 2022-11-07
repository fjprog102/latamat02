// See https://aka.ms/new-console-template for more information
Console.WriteLine("Write Input:");
var input = Console.ReadLine();

Console.WriteLine($"Is vowel: {isVowel(input[0])}");

bool isVowel(char letter) {
    return letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u';
}
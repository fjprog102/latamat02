// See https://aka.ms/new-console-template for more information

string removeVowels(string input) {

    string output = "";
    char[] vowels = {'a', 'e', 'i', 'o', 'u'};

    for (int i=0; i<input.Length; i++) {
        
        if (!vowels.Contains(Char.ToLower(input[i]))) {
            output += input[i];
        }
    }

    return output;

}


Console.WriteLine(removeVowels("This website is for losers LOL!"));

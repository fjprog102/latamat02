namespace Trolls.Joaquin {
    public class TrollsText {
        public string removeVowels (string input) {
            string output = "";
            char[] vowels = {'a', 'e', 'i', 'o', 'u'};

            for (int i=0; i<input.Length; i++) {
                
                if (!vowels.Contains(Char.ToLower(input[i]))) {
                    output += input[i];
                }
            }

            return output;
        }
    }
}

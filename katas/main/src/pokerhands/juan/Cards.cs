namespace CardJuan
{
    //public class Card
    public class Card
    {
        private readonly char suit;
        private readonly char value;
        private readonly int weigth;

        public Card(string input)
        {
            value = input[0];
            suit = input[1];
            weigth = ParsedValue(value);
        }

        public char SuitAttr => suit;
        public char ValueAttr => value;
        public int WeigthAttr => weigth;

        private int ParsedValue(char value)
        {
            char[] values = { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };
            return Array.IndexOf(values, value) + 1;
        }

        public string ToStr()
        {
            return string.Format("suit:{0} value:{1} weigth:{2}", suit, value, weigth);
        }
    }
}

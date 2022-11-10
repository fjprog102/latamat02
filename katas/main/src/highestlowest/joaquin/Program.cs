namespace HighestLowest.Joaquin
{
    public class HighestLowestClass
    {
        public string HighAndLow(string input)
        {
            if (!input.Contains(' '))
            {
                return $"{input} {input}";
            }

            string[] inputStringArray = input.Split(' ');
            int[] inputIntegersArray = new int[inputStringArray.Length];

            for (int i = 0; i < inputStringArray.Length; i++)
            {
                inputIntegersArray[i] = int.Parse(inputStringArray[i]);
            }

            Array.Sort(inputIntegersArray);

            return $"{inputIntegersArray[inputIntegersArray.Length - 1]} {inputIntegersArray[0]}";
        }
    }
}

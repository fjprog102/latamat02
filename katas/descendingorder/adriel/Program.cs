namespace DescendingOrder.Adriel;

public class DescendingOrder {
    public int getDescendingOrder(int number)
    {
        char[] inputString = Convert.ToString(number).ToArray();

        Array.Sort(inputString);
        Array.Reverse(inputString);

        string resString = String.Join("", inputString);
        int res = Convert.ToInt32(resString);

        return res;
    }
}
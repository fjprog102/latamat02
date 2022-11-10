namespace DescendingOrder.Jorge;
public class DescendingOrder
{
    public int Number(int num)
    {
        char[] numArray = num.ToString().ToCharArray();
        Array.Sort(numArray);
        Array.Reverse(numArray);
        var sortedNumber = new string(numArray);
        return int.Parse(sortedNumber);
    }
}
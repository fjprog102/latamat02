namespace KOT.Models;

using KOT.Models.Abstracts;

public class TokyoBoard : Element
{
    public List<Player> TokyoCity = new List<Player>();
    public List<Player>? TokyoBay;
    public List<Player> OutsideTokyo = new List<Player>();
}

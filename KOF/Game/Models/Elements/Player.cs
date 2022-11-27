using KOT.Models.Abstracts;

namespace KOT.Models;

public class Player : Element
{
    public int? PID { get; set; }
    public string? Name { get; set; }
    public Monster? MyMonster { get; set; }
}

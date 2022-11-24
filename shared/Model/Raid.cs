namespace shared.Model;

public class Raid
{
    public int RaidId { get; set; }
    public string RaidName { get; set; }

    public List<Boss> Bosses { get; set; } = new List<Boss>();
}
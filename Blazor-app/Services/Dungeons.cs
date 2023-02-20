namespace Services.Dungeons;

public class Run
{
    public string dungeon { get; set; }
    public int mythicLevel { get; set; }
    public int clearTime { get; set; }
    public int parTime { get; set; }
    public int numKeystoneUpgrades { get; set; }
    public double score { get; set; }
}

public class Dungeons
{
    public List<Run> fortified { get; set; }
    public List<Run> tyrannical { get; set; }

    public Dungeons()
    {
        fortified = new List<Run>();
        tyrannical = new List<Run>();
        for (int i = 0; i < 8; i++)
        {
            fortified.Add(
                new Run
                {
                    dungeon = Convert.ToString(i + 1),
                    mythicLevel = 0,
                    clearTime = 0,
                    parTime = 0,
                    numKeystoneUpgrades = 1,
                    score = 0
                }
            );
            tyrannical.Add(
                new Run
                {
                    dungeon = Convert.ToString(i + 1),
                    mythicLevel = 0,
                    clearTime = 0,
                    parTime = 0,
                    numKeystoneUpgrades = 1,
                    score = 0
                }
            );
        }
    }
}

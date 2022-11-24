namespace shared.Model;

public class Boss
{
    public int BossId { get; set; }
    public string BossName { get; set; }

    public List<Ability> Abilities { get; set; } = new List<Ability>();
}
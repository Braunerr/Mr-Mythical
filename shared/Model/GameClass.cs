namespace shared.Model;

public class GameClass
{
    public int GameClassId { get; set; }
    public string GameClassName { get; set; }

    public List<Spell> Spells { get; set; } = new List<Spell>();
}

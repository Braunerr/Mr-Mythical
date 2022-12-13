using shared.Model;

namespace Service;

public class DataService
{
    private DataContext db { get; }

    public DataService(DataContext db)
    {
        this.db = db;
    }

    public void SeedData()
    {
        Raid raid = db.Raids.FirstOrDefault()!;
        if (raid == null)
        {
            raid = new Raid { RaidId = 14030, RaidName = "Vault of the Incarnates" };
            db.Raids.Add(raid);
            db.SaveChanges();
        }

        Boss boss = db.Bosses.FirstOrDefault()!;
        if (boss == null)
        {
            raid.Bosses.Add(new Boss { BossName = "Eranog" });
            raid.Bosses.Add(new Boss { BossName = "Terros" });
            raid.Bosses.Add(new Boss { BossName = "The Primal Coucil" });
            raid.Bosses.Add(new Boss { BossName = "Sennarth, the Cold Breath" });
            raid.Bosses.Add(new Boss { BossName = "Dathea, Ascended" });
            raid.Bosses.Add(new Boss { BossName = "Kurog Grimtotem" });
            raid.Bosses.Add(new Boss { BossName = "Broodkeeper Diurna" });
            raid.Bosses.Add(new Boss { BossName = "Raszageth the Storm-Eater" });
            db.SaveChanges();
        }

        GameClass[] gameClasses = new GameClass[13];
        gameClasses[0] = db.GameClasses.FirstOrDefault()!;
        if (gameClasses[0] == null)
        {
            gameClasses[0] = new GameClass { GameClassName = "Death Knight" };
            gameClasses[1] = new GameClass { GameClassName = "Demon Hunter" };
            gameClasses[2] = new GameClass { GameClassName = "Druid" };
            gameClasses[3] = new GameClass { GameClassName = "Evoker" };
            gameClasses[4] = new GameClass { GameClassName = "Hunter" };
            gameClasses[5] = new GameClass { GameClassName = "Mage" };
            gameClasses[6] = new GameClass { GameClassName = "Monk" };
            gameClasses[7] = new GameClass { GameClassName = "Paladin" };
            gameClasses[8] = new GameClass { GameClassName = "Priest" };
            gameClasses[9] = new GameClass { GameClassName = "Rogue" };
            gameClasses[10] = new GameClass { GameClassName = "Shaman" };
            gameClasses[11] = new GameClass { GameClassName = "Warlock" };
            gameClasses[12] = new GameClass { GameClassName = "Warrior" };

            db.GameClasses.Add(gameClasses[0]);
            db.GameClasses.Add(gameClasses[1]);
            db.GameClasses.Add(gameClasses[2]);
            db.GameClasses.Add(gameClasses[3]);
            db.GameClasses.Add(gameClasses[4]);
            db.GameClasses.Add(gameClasses[5]);
            db.GameClasses.Add(gameClasses[6]);
            db.GameClasses.Add(gameClasses[7]);
            db.GameClasses.Add(gameClasses[8]);
            db.GameClasses.Add(gameClasses[9]);
            db.GameClasses.Add(gameClasses[10]);
            db.GameClasses.Add(gameClasses[11]);
            db.GameClasses.Add(gameClasses[12]);

            db.SaveChanges();
        }

        Spell spell = db.Spells.FirstOrDefault()!;
        if (spell == null)
        {
            gameClasses[0].Spells.Add(new Spell { Wowhead = 51052, SpellName = "Anti-Magic Zone" });

            gameClasses[1].Spells.Add(new Spell { Wowhead = 196718, SpellName = "Darkness" });

            gameClasses[2].Spells.Add(new Spell { Wowhead = 29166, SpellName = "Innervate" });
            gameClasses[2].Spells.Add(new Spell { Wowhead = 77761, SpellName = "Roar" });
            gameClasses[2].Spells.Add(new Spell { Wowhead = 740, SpellName = "Tranquility" });
            gameClasses[2].Spells.Add(new Spell { Wowhead = 33891, SpellName = "Tree of Life" });
            gameClasses[2].Spells.Add(new Spell { Wowhead = 391528, SpellName = "Convoke" });
            gameClasses[2].Spells.Add(new Spell { Wowhead = 197721, SpellName = "Flourish" });

            gameClasses[3].Spells.Add(new Spell { Wowhead = 374968, SpellName = "Time Spiral" });
            gameClasses[3].Spells.Add(new Spell { Wowhead = 374227, SpellName = "Zephyr" });
            gameClasses[3].Spells.Add(new Spell { Wowhead = 363534, SpellName = "Rewind" });
            db.SaveChanges();
        }
    }

    public List<GameClass> GetGameClasses()
    {
        return db.GameClasses.ToList();
    }

    public Player CreatePlayer(string playerName, int gameClassId)
    {
        GameClass gameClass = db.GameClasses.FirstOrDefault(a => a.GameClassId == gameClassId);
        db.Players.Add(new Player { PlayerName = playerName, GameClass = gameClass });
        db.SaveChanges();

        return null!;
    }
}

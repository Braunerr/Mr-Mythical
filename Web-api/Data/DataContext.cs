using Microsoft.EntityFrameworkCore;
using shared.Model;

namespace shared.Model
{
    public class DataContext : DbContext
    {
        public DbSet<Ability> Abilities => Set<Ability>();
        public DbSet<Boss> Bosses => Set<Boss>();
        public DbSet<Spell> Spells => Set<Spell>();
        public DbSet<Raid> Raids => Set<Raid>();
        public DbSet<GameClass> GameClasses => Set<GameClass>();
        public DbSet<Player> Players => Set<Player>();

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}

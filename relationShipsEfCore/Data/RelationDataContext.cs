using RelationShipsEfCore.Models;

namespace RelationShipsEfCore.Data
{
    public class RelationDataContext : DbContext
    {
        public RelationDataContext(DbContextOptions<RelationDataContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Character> characters { get; set; }
        public DbSet<Weapon> weapons { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SportBackend.DAL.Model;

namespace SportBackend.DAL.Data
{
    public class MySQLDBContext : DbContext
    {
        public MySQLDBContext(DbContextOptions options) : base(options) { }
       
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }

        public DbSet<Event> Event { get; set; }
    }
}

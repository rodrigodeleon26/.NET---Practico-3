using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class DBContext : DbContext
    {
        private string connectionString = "Data Source=Rodrigo\\SQLEXPRESS;Initial Catalog=PERSONAS;" +
                                          "Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False";

        public DBContext() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<Vehiculos> Vehiculos { get; set; }
    }
}
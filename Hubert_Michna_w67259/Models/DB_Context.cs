using Microsoft.EntityFrameworkCore;

namespace Hubert_Michna_w67259.Models
{
    public class DB_Context : DbContext
    {
        public DbSet<Typ_Wydatku> Typ_Wydatku { get; set; }
        public DbSet<Wydatek> Wydatek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=WIP_10;Integrated Security=True;Encrypt=False"); // Localhost z MS SQL
            optionsBuilder.UseSqlServer(@"server = 10.200.2.28; Database = Zal_w67259_ST2_v3; User Id = stud; Password =wsiz; "); // Server
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Typ_Wydatku>().HasData(
                new Typ_Wydatku()
                {
                    Id = 1,
                    Nazwa = "Produkty spożywcze"
                },
                new Typ_Wydatku()
                {
                    Id = 2,
                    Nazwa = "Motoryzacja"
                },
                new Typ_Wydatku()
                {
                    Id = 3,
                    Nazwa = "Edukacja"
                }
            );
        }
    }
}

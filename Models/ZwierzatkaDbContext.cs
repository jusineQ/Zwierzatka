using Microsoft.EntityFrameworkCore;
using Zwierzatka.Models;

namespace Zwierzatka.Models
{
    public class ZwierzatkaDbContext : DbContext
    {
        public ZwierzatkaDbContext(DbContextOptions<ZwierzatkaDbContext> options) : base(options) { }
        public DbSet<Uzytkownik> uzytkownicy { get; set; }
        public DbSet<Zwierze> zwierzeta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik {id = 1, nazwa = "jusin", haslo = "haslo"},
                new Uzytkownik { id = 2, nazwa = "Mamut", haslo = "maslo" }
            );

            modelBuilder.Entity<Zwierze>().HasData(
                new Zwierze { id = 1, imie = "Tropik", wiek = 6, rasa = "pies polski", zdjecie = "tropik.jpg", notatki = "Pies Jusina", uzytkownikId = 1},
                new Zwierze { id = 2, imie = "Frodo", wiek = 8, rasa = "Ragdoll", notatki = "Kot", uzytkownikId = 2 }
            );
        }
    }
}

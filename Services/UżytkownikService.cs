using Zwierzatka.Models;
using Microsoft.EntityFrameworkCore;
using Zwierzatka.Models;
using Zwierzatka.Services.Interfaces;

namespace Zwierzatka.Services
{
    public class UzytkownikService : IUżytkownikService
    {
        private readonly ZwierzatkaDbContext _db;

        public UzytkownikService(ZwierzatkaDbContext db)
        {
            _db = db;
        }

        //public async Task Zawiera(string imie, string haslo)
        //{


        //    return 1;
        //}

        public async Task<int> Zawiera(string imie, string haslo)
        {
            var s = _db.uzytkownicy.FirstOrDefault(u => u.nazwa == imie && u.haslo == haslo);
            if (s != null)
            {
                return s.id;
            }

            
            return 0;
        }

    }
}
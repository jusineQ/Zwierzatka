using Microsoft.EntityFrameworkCore;
using Zwierzatka.Models;
using Zwierzatka.Services.Interfaces;

namespace Zwierzatka.Services
{
    public class ZwierzetaService : IZwierzetaService
    {
        private readonly ZwierzatkaDbContext _db;

        public ZwierzetaService(ZwierzatkaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Zwierze>> PobierzlisteZwierzat(int id)
        {
            return await _db.zwierzeta.Where(x => x.uzytkownikId == id).ToListAsync();
        }

       


        public async Task Stwurz(Zwierze zwierzatka)
        {
            _db.zwierzeta.Add(zwierzatka);
            await _db.SaveChangesAsync();
        }

        public async Task Anihilacja(int id)
        {
            var zwierze = await _db.zwierzeta.Where(x => x.id == id).ToListAsync();
               // FindAsync(id);
                _db.zwierzeta.RemoveRange(zwierze);
            
                await _db.SaveChangesAsync();
            
        }

        public async Task Remake(Zwierze zwierzatka)
        {

             _db.zwierzeta.Update(zwierzatka);
   
             await _db.SaveChangesAsync();
            
        }
    }
}

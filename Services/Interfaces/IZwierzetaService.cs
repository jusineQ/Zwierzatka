using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zwierzatka.Models;

namespace Zwierzatka.Services.Interfaces
{
    public interface IZwierzetaService
    {
        Task<List<Zwierze>> PobierzlisteZwierzat(int id);

        Task Stwurz(Zwierze zwierzatka);
        Task Anihilacja(int id);
        Task Remake(Zwierze zwierzatka);
    }
}

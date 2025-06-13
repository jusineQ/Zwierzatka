using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zwierzatka.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Zwierzatka.Services.Interfaces;

namespace Zwierzatka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IZwierzetaService zw;
        private readonly IU퓓tkownikService us;

        public HomeController(ILogger<HomeController> logger, IZwierzetaService zwierzetaService,IU퓓tkownikService u퓓tkownikService)
        {
            _logger = logger;
            zw = zwierzetaService;
            us= u퓓tkownikService;
        }

        
        public IActionResult Index(int i)
        {
            ViewBag.IID = i;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Index(Uzytkownik uzytkownik)
        {
            int s = await us.Zawiera(uzytkownik.nazwa, uzytkownik.haslo);

            if (s ==0)
            {
                
                return RedirectToAction("Index", new { i = 1});
            } else 
            {
                return RedirectToAction("Lista", new {i=s});
            }
        }

        public async Task<IActionResult> Lista(int i)
        {
            ViewBag.LID = i;

            var zwierzeta = await zw.PobierzlisteZwierzat(i);
            return View(zwierzeta);
        }

        public async Task<IActionResult> Delete(int id, int uid)
        {
            await zw.Anihilacja(id);
            return RedirectToAction("Lista", new { i = uid });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dodaj(int idUzytkownika)
        {
            ViewBag.IDU = idUzytkownika;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj(Zwierze zwierzew)
        {
            var uid = zwierzew.uzytkownikId;
            await zw.Stwurz(zwierzew);

            
            return RedirectToAction("Lista", new { i = uid });
        }

        public IActionResult Edit(int id, string name, int age,string type , string notes, int uid)
        {
            ViewBag.id = id;
            ViewBag.name = name;
            ViewBag.age = age;
            ViewBag.type = type;
            ViewBag.notes = notes;
            ViewBag.uid = uid;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Zwierze zwierze2)
        {

            await zw.Remake(zwierze2);
            return RedirectToAction("Lista", new { i = zwierze2.uzytkownikId});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

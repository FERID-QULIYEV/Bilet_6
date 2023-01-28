using Bilet_6.DAL;
using Bilet_6.Models;
using Bilet_6.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        AppDbContext _context { get;}
        IWebHostEnvironment _env { get; }
        public TeamController(AppDbContext context,IWebHostEnvironment env)
        {
            _context= context;
            _env= env;
        }
        public IActionResult Index()
        {
            return View(_context.Teams.ToList());

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamVM teamVM)
        {
            if (!ModelState.IsValid) return View();
            CheckOrder:
            IFormFile file = teamVM.Image;
            if (!file.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Yuklediyiniz fayl shekil deyil");
                return View();
            }
            if (file.Length > 200 * 1024)
            {
                ModelState.AddModelError("Image", "Shekilin olcusu 200 kb-dan artiq ola bilmez");
                return View();
            }
            string fileName = Guid.NewGuid() + file.FileName;
            using (var stream = new FileStream(Path.Combine(_env.WebRootPath, "assets", "img", fileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Team team = new Team { Name=teamVM.Name, Surname=teamVM.Surname, Image = fileName, PozitionId=teamVM.PozitionId,  Description = teamVM.Description, Facebook = teamVM.Facebook, GooglePlus =teamVM.GooglePlus,/* Pozition =teamVM.Pozition ,*/  Linkedin =teamVM.Linkedin  };
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            Team team = _context.Teams.Find(id);
            if (team is null) return NotFound();
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
 }

using Bilet_6.DAL;
using Bilet_6.Models;
using Bilet_6.ViewModel;
using Bilet_6.ViewModel.Account;
using Bilet_6.ViewModel.Pozition;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_6.Areas.Manage.Controllers
{
    public class PozitionController: Controller
    {
        AppDbContext _context { get; }
        public PozitionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Pozitions.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async IActionResult Create(PozitionVM pozitionvm)
        //{
        //    Pozition pozition = new PozitionP;
        //    _context.Pozitions.Add(pozition);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            Pozition pozition = _context.Pozitions.Find(id);
            _context.Pozitions.Remove(pozition);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}

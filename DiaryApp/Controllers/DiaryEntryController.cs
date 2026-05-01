using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaryEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> entries = _context.DiaryEntries.ToList();
            
            return View(entries);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            _context.DiaryEntries.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index","DiaryEntry");
        }
    }
}

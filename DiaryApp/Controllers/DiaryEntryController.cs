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
            // Eğer nesne boş değilse ve Başlık (Title) 3 karakterden kısaysa hata mesajı ekle
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Başlık en az 3 karakter uzunluğunda olmalıdır.");
            }

            // Eğer model doğrulama kurallarından geçtiyse (hata yoksa)
            if (ModelState.IsValid)
            {
                _context.DiaryEntries.Add(obj);   // Yeni günlük girişini veritabanı setine ekler
                _context.SaveChanges();          // Yapılan değişiklikleri veritabanına kaydeder

                // Kullanıcıyı DiaryEntry kontrolcüsündeki Index sayfasına (listeleme ekranına) yönlendirir
                return RedirectToAction("Index", "DiaryEntry");
            }

            // Eğer model geçerli değilse, hataları göstererek aynı sayfayı (formu) tekrar yükler
            return View(obj);

        }
    }
}

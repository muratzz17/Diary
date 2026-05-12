using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DiaryApp.Controllers
{
    public class DiaryEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Veritabanı bağlantısını (DbContext) Constructor üzerinden içeri alıyoruz (Dependency Injection)
        public DiaryEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Günlük girişlerini listeleyen ana sayfa metodu
        public IActionResult Index()
        {
            // Veritabanındaki tüm günlük girişlerini bir liste olarak çeker
            List<DiaryEntry> entries = _context.DiaryEntries.ToList();

            // Çekilen verileri View'a (Arayüz tarafına) gönderir
            return View(entries);
        }

        // Yeni bir günlük girişi oluşturma sayfasını açan GET metodu
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

        // Belirli bir kaydı düzenlemek için verileri getiren sayfa
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // Eğer ID parametresi gönderilmemişse veya 0 ise "Bulunamadı" hatası döndürür
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Veritabanında bu ID'ye sahip olan kaydı arar
            DiaryEntry? diary = _context.DiaryEntries.Find(id);

            // Eğer veritabanında böyle bir kayıt yoksa hata döndürür
            if (diary == null)
            {
                return NotFound();
            }

            // Bulunan kayıt verilerini düzenleme formuna doldurması için View'a gönderir
            return View(diary);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry entry)
        {
            // Başlık uzunluğu kontrolünü burada da yapıyoruz (Güvenlik ve iş kuralı)
            if (entry != null && entry.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Başlık en az 3 karakter uzunluğunda olmalıdır.");
            }

            // Eğer yapılan değişiklikler geçerliyse (Validasyon başarılıysa)
            if (ModelState.IsValid)
            {
                _context.DiaryEntries.Update(entry); // Mevcut kaydı yeni verilerle günceller
                _context.SaveChanges();               // Değişiklikleri veritabanına işler

                // Başarılı işlem sonrası liste ekranına döner
                return RedirectToAction("Index", "DiaryEntry");
            }

            // Geçersiz bir durum varsa aynı formu hatalarla beraber tekrar gösterir
            return View(entry);
        }

        // Silme onay sayfasını gösteren metot
        public IActionResult Delete(int? id)
        {
            // ID kontrolü yapar, geçersizse "Bulunamadı" döndürür
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Silinecek olan kaydı ID üzerinden veritabanında bulur
            DiaryEntry? diary = _context.DiaryEntries.Find(id);

            // Kayıt mevcut değilse hata döndürür
            if (diary == null)
            {
                return NotFound();
            }

            // Silinecek kaydı onay sayfasına (View) gönderir
            return View(diary);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry entry)
        {
            // Gelen nesneyi veritabanındaki tablodan silinmek üzere işaretler
            _context.DiaryEntries.Remove(entry);

            // Silme işlemini veritabanında gerçekleştirir
            _context.SaveChanges();

            // İşlem tamamlandıktan sonra ana listeye yönlendirir
            return RedirectToAction("Index", "DiaryEntry");
        }
    }
}
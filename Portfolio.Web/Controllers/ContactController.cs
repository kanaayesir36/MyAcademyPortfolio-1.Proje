using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities; // ContactInfo sınıfı için

namespace Portfolio.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        // Index sayfası
        public IActionResult Index()
        {
            var items = _context.ContactInfos.ToList(); // Birden fazla kayıt varsa liste döner
            return View(items);
        }

        // GET: Güncelleme sayfası
        [HttpGet]
        public IActionResult UpdateContact(int? id)
        {
            if (id == null)
            {
                // Eğer id verilmemişse, ilk kaydı getir
                var firstItem = _context.ContactInfos.FirstOrDefault();
                if (firstItem == null)
                    return NotFound();
                return View(firstItem);
            }

            var item = _context.ContactInfos.FirstOrDefault(c => c.ContactInfoId == id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Güncelleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(int id, [Bind("Address,PhoneNumber,Email,MapUrl")] ContactInfo model)
        {
            if (!ModelState.IsValid)
            {
                // ModelState hatalıysa aynı view'e modeli geri gönder
                model.ContactInfoId = id; // id'yi set et
                return View(model);
            }

            var contact = _context.ContactInfos.FirstOrDefault(c => c.ContactInfoId == id);
            if (contact == null)
                return NotFound();

            // Güncelle
            contact.Address = model.Address;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Email = model.Email;
            contact.MapUrl = model.MapUrl;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

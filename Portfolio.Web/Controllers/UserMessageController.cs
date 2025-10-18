using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Async metodlar için
using Portfolio.Web.Context; // DbContext'i dahil edin
using Portfolio.Web.Entities;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly PortfolioContext _context; // Context'i tutacak alan

        // Constructor ile DbContext'i Dependency Injection (DI) yoluyla alıyoruz
        public UserMessageController(PortfolioContext context)
        {
            _context = context;
        }

        /**
         * GET: /UserMessage
         * Context üzerinden tüm mesajları çeker.
         */
        public async Task<IActionResult> Index()
        {
            var messages = await _context.UserMessages
                                         .OrderByDescending(m => m.UserMessageId)
                                         .ToListAsync();

            return View(messages);
        }

        
        [HttpPost]
       
        public async Task<IActionResult> ToggleRead(int id)
        {
            var message = await _context.UserMessages.FirstOrDefaultAsync(m => m.UserMessageId == id);

            if (message == null)
            {
                return NotFound();
            }

            message.IsRead = !message.IsRead;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var message = _context.UserMessages.FirstOrDefault(m => m.UserMessageId == id);
            if (message == null) return NotFound();

            return View(message);
        }
    }
}

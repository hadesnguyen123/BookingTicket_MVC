using BookingTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        // bất đồng bộ, chờ kết quả trả về từ ToListAsync(), ko cần chặn luống ứng dụng
        
        public async Task<IActionResult> Index()
        {
            var allProducers =await _context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}

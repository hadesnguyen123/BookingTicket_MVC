using BookingTicket.Data;
using BookingTicket.Data.Services;
using BookingTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTicket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        // bất đồng bộ, chờ kết quả trả về từ ToListAsync(), ko cần chặn luống ứng dụng
        public IActionResult Index()
        {
            var allProducer = _service.GetAll();
            return View(allProducer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public IActionResult Details(int id)
        {
            var producerDetails = _service.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        //Get: Actors/Edit/id
        public IActionResult Edit(int id)
        {
            var producerDetails = _service.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        //Post: Actors/Edit
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _service.Update(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/id
        public IActionResult Delete(int id)
        {
            var producerDetails = _service.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        //Post: Actors/Edit
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails = _service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using BookingTicket.Data;
using BookingTicket.Data.Services;
using BookingTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data =  _service.GetAll();
            return View(data);
        }

        //Get: Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public IActionResult Details(int id)
        {
            var actorDetails = _service.GetById(id);
            if(actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        //Get: Actors/Edit/id
        public IActionResult Edit(int id)
        {
            var actorDetails = _service.GetById(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        //Post: Actors/Edit
        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/id
        public IActionResult Delete(int id)
        {
            var actorDetails = _service.GetById(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        //Post: Actors/Edit
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var actorDetails = _service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

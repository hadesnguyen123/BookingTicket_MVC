using BookingTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTicket.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }


        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var actor = _context.Actors.FirstOrDefault(x => x.Id == id);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }

        public IEnumerable<Actor> GetAll()
        {
            var result =  _context.Actors.ToList();
            return result;
        }


        public Actor GetById(int id)
        {
            return _context.Actors.FirstOrDefault(x => x.Id == id);
        }

        public Actor Update(int id, Actor newActor)
        {
            _context.Update(newActor);
            _context.SaveChanges();
            return newActor;
        }
    }
}

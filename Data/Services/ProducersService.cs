using BookingTicket.Models;

namespace BookingTicket.Data.Services
{
    public class ProducersService : IProducersService
    {

        private readonly AppDbContext _context;
        public ProducersService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var producer = _context.Producers.FirstOrDefault(x => x.Id == id);
            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }

        public IEnumerable<Producer> GetAll()
        {
            var result = _context.Producers.ToList();
            return result;
        }

        public Producer GetById(int id)
        {
            return _context.Producers.FirstOrDefault(x => x.Id == id);
        }

        public Producer Update(int id, Producer newProducer)
        {
            _context.Update(newProducer);
            _context.SaveChanges();
            return newProducer;
        }
    }
}

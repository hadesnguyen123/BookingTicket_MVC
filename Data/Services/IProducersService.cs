using BookingTicket.Models;

namespace BookingTicket.Data.Services
{
    public interface IProducersService
    {
        IEnumerable<Producer> GetAll();
        Producer GetById(int id);
        void Add(Producer producer);
        Producer Update(int id, Producer newProducer);
        void Delete(int id);
    }
}

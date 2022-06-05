using TicketSystem.Models;
using TicketSystem.Models;
namespace TicketSystem.Repository
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();

        Ticket GetByMobile(string mobile);

        Ticket Post(Ticket ticket);

        bool IsTimeAvailable(DateTime startTime, DateTime endTime);

        void Save();
    }
}

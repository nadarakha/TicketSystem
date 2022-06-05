using TicketSystem.Models;

namespace TicketSystem.Repository
{
    public interface IPatiantRepository
    {
        Patient GetByMobile(string mobile);
    }
}

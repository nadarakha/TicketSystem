using TicketSystem.Models;
namespace TicketSystem.Repository
{
    public class PatiantRepository : IPatiantRepository
    {
        private readonly ApplicationDbContext _context;
        public PatiantRepository()
        {
            _context = new ApplicationDbContext();
        }
        public PatiantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Patient GetByMobile(string mobile)
        {

            return _context.Patients.SingleOrDefault(p => p.Mobile == mobile);
        }
    }
}

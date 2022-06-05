using TicketSystem.Models;

namespace TicketSystem.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketRepository()
        {
            _context = new ApplicationDbContext();
        }
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.OrderByDescending(t => t.Id).ToList();
        }

        public Ticket GetByMobile(string mobile)
        {
            var ticket = from p in _context.Patients
                         join t in _context.Tickets
                         on p.Id equals t.PatientId
                         where p.Mobile == mobile
                         select t;

            return ticket?.SingleOrDefault();
        }

        public bool IsTimeAvailable(DateTime startTime, DateTime endTime)
        {
            return _context.Tickets.Any(t => (t.From <= startTime && t.From >= endTime) || (t.From <= startTime && t.From <= endTime) || endTime < t.To && t.From <= startTime);
        }

        public Ticket Post(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

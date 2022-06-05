using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;
using System.IO;
using CoreHtmlToImage;
using TicketSystem.Models;
using TicketSystem.Repository;
using TicketSystem.Application.ViewModels;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private ITicketRepository _ticketRepository;
        private IPatiantRepository _patiantRepository;

        public TicketsController()
        {
            _ticketRepository = new TicketRepository(new ApplicationDbContext());
            _patiantRepository = new PatiantRepository(new ApplicationDbContext());
        }

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _patiantRepository = new PatiantRepository(new ApplicationDbContext());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            return Ok(_ticketRepository.GetAll());
        }

        [HttpGet("{mobileNumber}")]
        public ActionResult<Ticket> GetTicketDetails(string mobileNumber)
        {
            return Ok(_ticketRepository.GetByMobile(mobileNumber));
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketTimeViewModel tiketTime)
        {
            var patient = _patiantRepository.GetByMobile(tiketTime.Mobile);

            if (patient == null) return NotFound();

            else

            {
                if (!IsTimeValid(tiketTime.From, tiketTime.To)) return Conflict("not valid time");

                if (!_ticketRepository.IsTimeAvailable(tiketTime.From, tiketTime.To)) return Conflict("time is already used");

                var ticket = new Ticket { PatientId = patient.Id, Date = DateTime.Now.Date, From = tiketTime.From, To = tiketTime.To };
                var ticketToAdd = _ticketRepository.Post(ticket);
                var html = $"<html><body><h1>Dr Khames</hr>Your Number Is:{ticketToAdd.Id}Your Time Is{tiketTime.From}-{tiketTime.To}</hr></h1></body></html>";
                var path = Utitilies.Utitilies.ConvertHtmlTOImage(html, patient.Id.ToString(), "jpeg");
                ticketToAdd.ImageUrl = path;
                _ticketRepository.Save();

                return ticketToAdd;
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        private bool IsTimeValid(DateTime startTime, DateTime endTime)
        {
            if (endTime < startTime) return false;

            return true;
        }
    }
}

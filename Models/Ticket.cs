using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Time)]
        public DateTime From { get; set; }

        [DataType(DataType.Time)]
        public DateTime To { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
       
        public virtual Patient Patient { get; set; }
    }
}

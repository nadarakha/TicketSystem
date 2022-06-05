using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Phone]
        [Required]
        public string Mobile { get; set; }
    }
}

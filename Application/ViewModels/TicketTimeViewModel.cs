using System.ComponentModel.DataAnnotations;
namespace TicketSystem.Application.ViewModels
{
    public class TicketTimeViewModel
    {
        [DataType(DataType.Time)]
        [Required]
        public DateTime From { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime To { get; set; }
        [Required]
        [Phone]
        public string Mobile { get; set; }
    }
}

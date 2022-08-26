using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class TicketMessage : Auditory
    {
        [Key]
        public int Id { get; set; }
        public Ticket? Ticket { get; set; }
        public string? Body { get; set; }
        public string? Fm { get; set; }
        public string? To { get; set; }
        public string? Status { get; set; }
    }
}

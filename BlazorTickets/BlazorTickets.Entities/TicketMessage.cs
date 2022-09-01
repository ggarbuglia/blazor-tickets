using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Entities
{
    public class TicketMessage : EntityBase
    {
        public Ticket? Ticket { get; set; }
        public string? Body { get; set; }
        public string? Fm { get; set; }
        public string? To { get; set; }
        public string? Status { get; set; }
    }
}

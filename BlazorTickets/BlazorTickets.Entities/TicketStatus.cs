using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Entities
{
    public class TicketStatus : EntityBase
    {
        public string? Name { get; set; }
    }
}
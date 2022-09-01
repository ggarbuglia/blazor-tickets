using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Entities
{
    public class TicketType : EntityBase
    {
        public string? Name { get; set; }
    }
}
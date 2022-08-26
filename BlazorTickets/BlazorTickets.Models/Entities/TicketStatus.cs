using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class TicketStatus : Auditory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
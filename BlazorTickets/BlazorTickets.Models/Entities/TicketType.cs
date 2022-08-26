using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class TicketType : Auditory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
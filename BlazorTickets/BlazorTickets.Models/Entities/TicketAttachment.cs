using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class TicketAttachment : Auditory
    {
        [Key]
        public int Id { get; set; }
        public Ticket? Ticket { get; set; }
        public string? FileContentType { get; set; }
        public string? FileName { get; set; }
        public string? FileLocalPath { get; set; }
        public string? Description { get; set; }
    }
}
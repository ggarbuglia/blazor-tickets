using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Entities
{
    public class TicketAttachment : EntityBase
    {
        public Ticket? Ticket { get; set; }
        public string? FileContentType { get; set; }
        public string? FileName { get; set; }
        public string? FileLocalPath { get; set; }
        public string? Description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class TicketAttachment : AuditableEntity<long>
    {
        [Column(Order = 6)]
        public Ticket? Ticket { get; set; }

        [Column(Order = 7)]
        public string? FileContentType { get; set; }

        [Column(Order = 8)]
        public string? FileName { get; set; }

        [Column(Order = 9)]
        public string? FileLocalPath { get; set; }

        [Column(Order = 10)]
        public string? Description { get; set; }
    }
}
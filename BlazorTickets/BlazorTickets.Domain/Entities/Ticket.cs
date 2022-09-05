using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class Ticket : AuditableEntity<long>
    {
        [Column(Order = 6)]
        public TicketType? Type { get; set; }

        [Column(Order = 7)]
        public string? Title { get; set; }

        [Column(Order = 8)]
        public string? Description { get; set; }

        [Column(Order = 9)]
        public SystemUser? RequestedFor { get; set; }

        [Column(Order = 10)]
        public string? Owner { get; set; }

        [Column(Order = 11)]
        public SystemGroup? OwnerGroup { get; set; }

        [Column(Order = 12)]
        public SystemUser? OwnerUser { get; set; }

        [Column(Order = 13)]
        public TicketStatus? Status { get; set; }

        [Column(Order = 14)]
        public DateTime? StatusDateTime { get; set; }

        public ICollection<TicketAttachment>? Attachments { get; set; }
        public ICollection<TicketMessage>? Messages { get; set; }
        public ICollection<TicketHistoryLog>? HistoryLogs { get; set; }
    }
}
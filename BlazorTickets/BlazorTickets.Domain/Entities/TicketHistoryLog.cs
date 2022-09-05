using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class TicketHistoryLog : AuditableEntity<long>
    {
        [Column(Order = 6)]
        public Ticket? Ticket { get; set; }

        [Column(Order = 7)]
        public SystemUser? ChangedBy { get; set; }

        [Column(Order = 8)]
        public DateTime? ChangedOn { get; set; }

        [Column(Order = 9)]
        public TicketStatus? OldStatus { get; set; }

        [Column(Order = 10)]
        public TicketStatus? NewStatus { get; set; }

        [Column(Order = 11)]
        public string? ChangeUserDesc { get; set; }

        [Column(Order = 12)]
        public string? ChangeSystemDesc { get; set; }

        [Column(Order = 13)]
        public SystemGroup? DelegatedGroup { get; set; }
    }
}

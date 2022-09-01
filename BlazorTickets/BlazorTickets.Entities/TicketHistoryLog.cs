using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Entities
{
    public class TicketHistoryLog : EntityBase
    {
        public Ticket? Ticket { get; set; }
        public SystemUser? ChangedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public TicketStatus? OldStatus { get; set; }
        public TicketStatus? NewStatus { get; set; }
        public string? ChangeUserDesc { get; set; }
        public string? ChangeSystemDesc { get; set; }
        public SystemGroup? DelegatedGroup { get; set; }
    }
}

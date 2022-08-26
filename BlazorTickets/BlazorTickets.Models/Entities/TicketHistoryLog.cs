using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class TicketHistoryLog
    {
        [Key]
        public Int64 Id { get; set; }
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

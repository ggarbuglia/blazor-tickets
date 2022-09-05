namespace BlazorTickets.DataObjects
{
    public class TicketHistoryLogDto : DtoBase<long>
    {
        public TicketDto? Ticket { get; set; }
        public SystemUserDto? ChangedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public TicketStatusDto? OldStatus { get; set; }
        public TicketStatusDto? NewStatus { get; set; }
        public string? ChangeUserDesc { get; set; }
        public string? ChangeSystemDesc { get; set; }
        public SystemGroupDto? DelegatedGroup { get; set; }
    }
}

namespace BlazorTickets.DataObjects
{
    public class TicketDto : DtoBase<long>
    {
        public TicketTypeDto? Type { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public SystemUserDto? RequestedFor { get; set; }
        public string? Owner { get; set; }
        public SystemGroupDto? OwnerGroup { get; set; }
        public SystemUserDto? OwnerUser { get; set; }
        public TicketStatusDto? Status { get; set; }
        public DateTime? StatusDateTime { get; set; }

        public ICollection<TicketAttachmentDto>? Attachments { get; set; }
        public ICollection<TicketMessageDto>? Messages { get; set; }
        public ICollection<TicketHistoryLogDto>? HistoryLogs { get; set; }
    }
}
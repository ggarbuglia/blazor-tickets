namespace BlazorTickets.DataObjects
{
    public class TicketAttachmentDto : DtoBase<long>
    {
        public TicketDto? Ticket { get; set; }
        public string? FileContentType { get; set; }
        public string? FileName { get; set; }
        public string? FileLocalPath { get; set; }
        public string? Description { get; set; }
    }
}
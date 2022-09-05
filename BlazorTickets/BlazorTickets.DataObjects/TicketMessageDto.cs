namespace BlazorTickets.DataObjects
{
    public class TicketMessageDto : DtoBase<long>
    {
        public TicketDto? Ticket { get; set; }
        public string? Body { get; set; }
        public string? Fm { get; set; }
        public string? To { get; set; }
        public string? Status { get; set; }
    }
}

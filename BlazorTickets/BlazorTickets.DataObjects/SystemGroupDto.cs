namespace BlazorTickets.DataObjects
{
    public class SystemGroupDto : DtoBase<int>
    {
        public string? Account { get; set; }
        public string? DisplayName { get; set; }
        public string? Mail { get; set; }
    }
}
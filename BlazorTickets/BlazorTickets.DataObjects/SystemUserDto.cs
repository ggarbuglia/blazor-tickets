namespace BlazorTickets.DataObjects
{
    public class SystemUserDto : DtoBase<int>
    {
        public string? Account { get; set; }
        public string? DisplayName { get; set; }
        public string? Mail { get; set; }
        public string? Department { get; set; }
    }
}
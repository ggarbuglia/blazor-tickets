using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Entities
{
    public class SystemUser : EntityBase
    {
        public string? Account { get; set; }
        public string? DisplayName { get; set; }
        public string? Mail { get; set; }
        public string? Department { get; set; }
    }
}
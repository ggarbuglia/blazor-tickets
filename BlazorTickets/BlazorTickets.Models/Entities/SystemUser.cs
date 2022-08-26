using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class SystemUser
    {
        [Key]
        public int Id { get; set; }
        public string? Account { get; set; }
        public string? DisplayName { get; set; }
        public string? Mail { get; set; }
        public string? Department { get; set; }
    }
}
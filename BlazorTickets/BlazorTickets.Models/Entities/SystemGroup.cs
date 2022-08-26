using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class SystemGroup
    {
        [Key]
        public int Id { get; set; }
        public string? Account { get; set; }
        public string? DisplayName { get; set; }
        public string? Mail { get; set; }
    }
}
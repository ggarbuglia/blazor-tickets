using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTickets.Domain.Entities
{
    public class SystemUser : AuditableEntity<int>
    {
        [Column(Order = 6)]
        public string? Account { get; set; }

        [Column(Order = 7)]
        public string? DisplayName { get; set; }

        [Column(Order = 8)]
        public string? Mail { get; set; }

        [Column(Order = 9)]
        public string? Department { get; set; }
    }
}
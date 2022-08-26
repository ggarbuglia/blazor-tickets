﻿using System.ComponentModel.DataAnnotations;

namespace BlazorTickets.Models.Entities
{
    public class Ticket : Auditory
    {
        [Key]
        public Int64 Id { get; set; }
        public TicketType? Type { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public SystemUser? RequestedFor { get; set; }
        public string? Owner { get; set; }
        public SystemGroup? OwnerGroup { get; set; }
        public SystemUser? OwnerUser { get; set; }
        public TicketStatus? Status { get; set; }
        public DateTime? StatusDateTime { get; set; }

        public ICollection<TicketAttachment>? Attachments { get; set; }
        public ICollection<TicketMessage>? Messages { get; set; }
        public ICollection<TicketHistoryLog>? HistoryLogs { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using BlazorTickets.Models.Entities;

namespace BlazorTickets.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SystemGroup>? SystemGroups { get; set; }
        public DbSet<SystemUser>? SystemUsers { get; set; }
        public DbSet<TicketType>? TicketTypes { get; set; }
        public DbSet<TicketStatus>? TicketStatuses { get; set; }
        public DbSet<TicketMessage>? TicketMessages { get; set; }
        public DbSet<TicketHistoryLog>? TicketHistorylogs { get; set; }
        public DbSet<TicketAttachment>? TicketAttachments { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemGroup>(e => {
                e.Property(p => p.Account).HasColumnType("varchar(50)").IsRequired();
                e.Property(p => p.DisplayName).HasColumnType("varchar(150)");
                e.Property(p => p.Mail).HasColumnType("varchar(300)");
            });

            modelBuilder.Entity<SystemUser>(e => {
                e.Property(p => p.Account).HasColumnType("varchar(50)").IsRequired();
                e.Property(p => p.DisplayName).HasColumnType("varchar(150)");
                e.Property(p => p.Mail).HasColumnType("varchar(300)");
                e.Property(p => p.Department).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TicketType>(e => {
                e.Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            });

            modelBuilder.Entity<TicketStatus>(e => {
                e.Property(p => p.Name).HasColumnType("varchar(50)").IsRequired();
            });

            modelBuilder.Entity<TicketMessage>(e => {
                e.Property(p => p.Body).HasColumnType("ntext").IsRequired();
                e.Property(p => p.Fm).HasColumnType("varchar(150)").IsRequired();
                e.Property(p => p.To).HasColumnType("varchar(150)").IsRequired();
                e.Property(p => p.Status).HasColumnType("varchar(50)").IsRequired();
            });

            modelBuilder.Entity<TicketHistoryLog>(e => {
                e.Property(p => p.ChangeUserDesc).HasColumnType("ntext").IsRequired();
                e.Property(p => p.ChangeUserDesc).HasColumnType("varchar(1000)").IsRequired();
            });

            modelBuilder.Entity<TicketAttachment>(e => {
                e.Property(p => p.FileContentType).HasColumnType("varchar(50)").IsRequired();
                e.Property(p => p.FileName).HasColumnType("varchar(50)").IsRequired();
                e.Property(p => p.FileLocalPath).HasColumnType("varchar(500)").IsRequired();
                e.Property(p => p.Description).HasColumnType("varchar(1000)").IsRequired();
            });

            modelBuilder.Entity<Ticket>(e => {
                e.Property(p => p.Title).HasColumnType("varchar(200)").IsRequired();
                e.Property(p => p.Description).HasColumnType("ntext").IsRequired();
                e.Property(p => p.Owner).HasColumnType("varchar(150)").IsRequired();
            });
        }
    }
}
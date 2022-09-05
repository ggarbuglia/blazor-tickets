namespace BlazorTickets.Domain.Contracts
{
    public interface IAuditableEntity : IEntity
    {
        string? CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string? UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
    }

    public interface IAuditableEntity<IdT> : IAuditableEntity, IEntity<IdT>
    {
    }
}

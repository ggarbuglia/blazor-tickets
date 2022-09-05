namespace BlazorTickets.Domain.Contracts
{
    public interface IEntity
    {
    }

    public interface IEntity<IdT> : IEntity
    {
        public IdT? Id { get; set; }
    }
}

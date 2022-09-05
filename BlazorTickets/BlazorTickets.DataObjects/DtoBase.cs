namespace BlazorTickets.DataObjects
{
    public abstract class DtoBase<IdT>
    {
        public IdT? Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
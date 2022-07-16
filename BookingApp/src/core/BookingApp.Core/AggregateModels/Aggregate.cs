namespace BookingApp.Core.AggregateModels
{
    public abstract class Aggregate<TId> : Entity, IAggregate<TId>
    {
        public TId Id { get; protected set; }
    }
}

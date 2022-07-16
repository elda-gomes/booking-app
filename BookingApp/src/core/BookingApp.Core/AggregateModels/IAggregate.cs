namespace BookingApp.Core.AggregateModels
{
    public interface IAggregate<out T> : IAggregate
    {
        T Id { get; }
    }

    public interface IAggregate
    { 
    }
}

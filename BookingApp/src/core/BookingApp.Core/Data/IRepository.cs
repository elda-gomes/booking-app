using BookingApp.Core.AggregateModels;

namespace BookingApp.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregate
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

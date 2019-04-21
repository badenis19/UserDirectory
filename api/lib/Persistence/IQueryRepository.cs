using System.Linq;

namespace App.Library.Persistence
{
  public interface IQueryRepository<E> where E : IAggregateRoot
  {
    IQueryable<E> Entities { get; }
  }
}
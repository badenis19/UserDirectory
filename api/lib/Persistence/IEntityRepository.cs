using System;
using System.Linq;
using System.Linq.Expressions;

namespace App.Library.Persistence
{
  public interface IEntityRepository<E> where E : IAggregateRoot
  {
    IQueryable<E> Entities { get; }

    void Add(E entity);

    void Remove(E entity);

    void Update(E entity);
  }
}
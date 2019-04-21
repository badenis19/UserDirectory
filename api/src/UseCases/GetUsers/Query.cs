using System;
using System.Collections.Generic;
using App.Library.CodeStructures.Behavioural;
using UserApi.Models;

namespace UserApi.UseCases
{
  public class GetUsers : IQueryFor<GetUsersPayload>
  {
    public int Page { get; set; }
    public int PageSize { get; set; }
    public OrderingBasis OrderingType { get; set; } = OrderingBasis.creationDateDesc;
  }

  public class GetUsersPayload
  {
    public IEnumerable<User> Users { get; set; }
    public int Page { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
  }

  public enum OrderingBasis
  {
    alphabeticalAsc,
    alphabeticalDesc,
    creationDateAsc,
    creationDateDesc
  }
}

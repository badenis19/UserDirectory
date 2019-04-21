using System;
using System.Collections.Generic;
using System.Linq;
using App.Library.CodeStructures.Behavioural;
using App.Library.Persistence;
using UserApi.Models;

namespace UserApi.UseCases
{
  public class GetUsersHandler : IQueryHandler<GetUsers, GetUsersPayload>
  {
    private readonly IEntityRepository<User> userRepository;

    public GetUsersHandler(IEntityRepository<User> aUserRepository)
    {
      userRepository = Guard.IsNotNull(aUserRepository, nameof(aUserRepository));
    }

    private (bool ascending, Func<User, object> selector) ResolveOrdering(GetUsers request)
    {
      switch (request.OrderingType)
      {
        case OrderingBasis.alphabeticalAsc:
          return (true, user => user.Email);

        case OrderingBasis.alphabeticalDesc:
          return (false, user => user.Email);

        case OrderingBasis.creationDateAsc:
          return (true, user => user.RegisteredOn);

        default:
          return (false, user => user.RegisteredOn);

      }
    }

    public QueryResponse<GetUsersPayload> Handle(GetUsers request)
    {
      Guard.IsNotNull(request, nameof(request));

      var pageSize = request.PageSize > 0 ? request.PageSize : 5;
      var pageNumber = request.Page > 0 ? request.Page : 1;

      var ordering = ResolveOrdering(request);

      var users = userRepository
                      .Entities
                      .Order(ordering.selector, ordering.ascending)
                      .Skip((pageNumber - 1) * pageSize)
                      .Take(pageSize + 1);

      var payload = new GetUsersPayload()
      {
        Page = pageNumber,
        HasNextPage = users.Count() > pageSize,
        HasPreviousPage = pageNumber > 1,
        Users = users.Take(pageSize)
      };

      return QueryResponse<GetUsersPayload>.Success(payload);
    }
  }
}

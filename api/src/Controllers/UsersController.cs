using System.Collections.Generic;
using App.Library.CodeStructures.Behavioural;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.UseCases;

namespace UserApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : BaseController
  {
    private readonly ICommandHandler<RegisterUser> registerUserHandler;
    private readonly IQueryHandler<GetUsers, GetUsersPayload> getUsersHandler;

    public UsersController(
      ICommandHandler<RegisterUser> registerUserHandler,
      IQueryHandler<GetUsers, GetUsersPayload> getUsersHandler
    )
    {
      this.registerUserHandler = Guard.IsNotNull(registerUserHandler, nameof(registerUserHandler));
      this.getUsersHandler = Guard.IsNotNull(getUsersHandler, nameof(getUsersHandler));
    }

    [HttpGet]
    public IActionResult GetUsers([FromQuery]GetUsers request)
    {
      var response = getUsersHandler.Handle(request);

      return BuildHttpResponse(response);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody]RegisterUser request)
    {
      var response = registerUserHandler.Handle(request);

      return BuildHttpResponse(response);
    }
  }
}
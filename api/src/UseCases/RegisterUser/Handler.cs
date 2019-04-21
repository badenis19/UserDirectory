using System;
using System.Collections.Generic;
using System.Linq;
using App.Library.CodeStructures.Behavioural;
using App.Library.CodeStructures.Behavioural.Validation;
using App.Library.Persistence;
using UserApi.Models;

namespace UserApi.UseCases
{
  public class RegisterUserHandler : ICommandHandler<RegisterUser>
  {
    private readonly IEntityRepository<User> userRepository;
    public RegisterUserHandler(IEntityRepository<User> userRepository)
    {
      this.userRepository = Guard.IsNotNull(userRepository, nameof(userRepository));
    }

    private IEnumerable<IResponseMessage> Validate(RegisterUser request)
    {
      Guard.IsNotNull(request.Email, "request.Email");
      Guard.IsNotNull(request.Password, "request.Password");

      /* 
       * The user model is valid if
       * email is not empty
       * email contains the `@` character
       * password is at least 8 characters
       * password contains one upper -case letter, one lower-case letter, one digit and one special character
       */

      return new PremiseValidator()
        .For(request.Email)
              .TextIsNotEmpty<EmailIsNotSpecified>()
              .Must<EmailLacksAtCharacter>(_ => request.Email.Contains("@"))
        .For(request.Password)
              .TextIsWithin<PasswordIsTooShort>(8)
              .Must<PasswordLacksUpperCaseCharacter>(_ => request.Password.Any(char.IsUpper))
              .Must<PasswordLacksLowerCaseCharacter>(_ => request.Password.Any(char.IsLower))
              .Must<PasswordLacksDigitCharacter>(_ => request.Password.Any(char.IsDigit))
              .Must<PasswordLacksSpecialCharacter>(_ => request.Password.Any(c => "@&*%!£#$%^".Contains(c)))
        .GetFailures();
    }

    public Response Handle(RegisterUser command)
    {

      var messages = Validate(command);

      if (messages.HasErrors())
      {
        return new Response(messages);
      }

      userRepository.Add(new User()
      {
        Id = Guid.NewGuid(),
        Email = command.Email,
        Password = command.Password
      });

      return Response.Success();
    }
  }
}
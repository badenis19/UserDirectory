using System;
using App.Library.CodeStructures.Behavioural;

namespace UserApi.UseCases
{
  public class RegisterUser : ICommand
  {
    public RegisterUser(string email, string password)
    {
      Email = Guard.IsNotNull(email, nameof(email));
      Password = Guard.IsNotNull(password, nameof(password));
    }
    public readonly string Email;
    public readonly string Password;
  }
}
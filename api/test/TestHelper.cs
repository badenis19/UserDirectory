using System;
using System.Collections.Generic;
using System.Linq;
using App.Library.Persistence;
using Moq;
using UserApi.Models;
using UserApi.UseCases;
using Xunit;

namespace test
{
  public class TestHelper
  {
    public const string MakeValidEmail = "h@x.yz";

    public const Char UpperCase = 'A';
    public const Char LowerCase = 'b';
    public const Char Digit = '0';
    public const Char SpecialChar = '!';


    public static string MakeValidPassword => $"{UpperCase}{LowerCase}{Digit}{SpecialChar}{UpperCase}{LowerCase}{Digit}{SpecialChar}";

    public static User MakeUser(string Email = null, string Password = null)
    {
      //DateTime.now has an accurracy of 15ms, this only poses a problem for the test ordering assertions
      //Realistically this won't be an issue on prod, it doesn't matter that 2 users may have been registered with the same datetime value
      System.Threading.Thread.Sleep(1);
      return new User()
      {
        Id = Guid.NewGuid(),
        Email = Email ?? MakeValidEmail,
        Password = Password ?? MakeValidPassword
      };
    }

    public static IQueryable<User> MakeRepo(params User[] users)
    {
      return new List<User>(users).AsQueryable();
    }
  }
}

using System;
using App.Library.Persistence;

namespace UserApi.Models
{
  public class User : IAggregateRoot
  {
    public User()
    {
      RegisteredOn = DateTime.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTime RegisteredOn { get; private set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
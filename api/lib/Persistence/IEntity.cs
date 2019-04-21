using System;
namespace App.Library.Persistence
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}

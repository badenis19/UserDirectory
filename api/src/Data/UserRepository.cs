using System.Collections.Generic;
using System.IO;
using System.Linq;
using App.Library.Persistence;
using Newtonsoft.Json;
using UserApi.Models;

namespace UserApi.Data
{
  public class UserRepository : IEntityRepository<User>
  {
    private IList<User> context;
    public UserRepository()
    {
      context = ReadFromDisk() ?? new List<User>();
    }

    public IQueryable<User> Entities => context.AsQueryable();

    public void Add(User entity)
    {
      context.Add(entity);
      WriteToDisk();
    }

    public void Remove(User entity)
    {
      context.Remove(entity);
      WriteToDisk();
    }

    public void Update(User entity)
    {
      throw new System.NotImplementedException();
    }

    private void WriteToDisk()
    {
      var json = JsonConvert.SerializeObject(context);
      System.IO.File.WriteAllText("repository.txt", json);
    }

    private IList<User> ReadFromDisk()
    {
      var json = System.IO.File.ReadAllText("repository.txt");
      return JsonConvert.DeserializeObject<IList<User>>(json);
    }
  }
}
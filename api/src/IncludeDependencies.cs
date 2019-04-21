using App.Library.CodeStructures.Behavioural;
using App.Library.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserApi.Data;
using UserApi.Models;

namespace UserApi
{
  public class IncludeDependencies
  {
    public static void ToServiceCollection(IServiceCollection services)
    {
      services.AddSingleton(
          typeof(IEntityRepository<User>),
          typeof(UserRepository)
      );

      services.Scan(scan => scan
                          .FromApplicationDependencies()
                          .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                          .AsImplementedInterfaces()
                          .WithTransientLifetime()
                    );

    }
  }
}
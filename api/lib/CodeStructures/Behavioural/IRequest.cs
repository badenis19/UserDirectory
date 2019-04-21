using System;
namespace App.Library.CodeStructures.Behavioural
{
  public interface IRequest : IRequest<Unit> { }


  public interface IRequest<out TResponse> { }

  public interface IRequestHandler<in TRequest, out TResponse> where TRequest : IRequest<TResponse>
  {
    TResponse Handle(TRequest message);
  }
}

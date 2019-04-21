using System.Collections.Generic;

namespace App.Library.CodeStructures.Behavioural
{
    public interface ICommand : IRequest<Response> { }

    public interface ICommandValidator<C> where C : ICommand
    {
        IEnumerable<IResponseMessage> Validate(C command);
    }

    public interface ICommandHandler<C> : IRequestHandler<C, Response> where C : ICommand
    {
    }
}

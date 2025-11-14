using Microsoft.Extensions.DependencyInjection;

namespace Application.Features
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _provider;
        public Dispatcher(IServiceProvider provider) => _provider = provider;

        public async Task<TResult> DispatchCommand<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
        {
            var handler = _provider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return await handler.Handle(command);
        }

        public async Task<TResult> DispatchQuery<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            var handler = _provider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return await handler.Handle(query);
        }
    }
}
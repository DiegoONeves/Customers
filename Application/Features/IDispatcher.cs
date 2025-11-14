namespace Application.Features
{
    public interface IDispatcher
    {
        Task<TResult> DispatchCommand<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>;

        Task<TResult> DispatchQuery<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>;
    }
}

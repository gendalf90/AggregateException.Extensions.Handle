using System;

namespace AggregateExceptionExtensions.Handler
{
    public interface IHandlerBuilder
    {
        IHandlerBuilder Handler<T>(Action<T> action) where T : Exception;

        IHandlerBuilder Handler<T>(Func<T, bool> predicate) where T : Exception;

        void Handle();
    }
}

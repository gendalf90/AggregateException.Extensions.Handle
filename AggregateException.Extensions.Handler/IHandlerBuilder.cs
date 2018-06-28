using System;

namespace AggregateExceptionExtensions.Handler
{
    public interface IHandlerBuilder
    {
        IHandlerBuilder Ignore<T>() where T : Exception;

        IHandlerBuilder Action<T>(Action<T> action) where T : Exception;

        IHandlerBuilder Predicate<T>(Func<T, bool> predicate) where T : Exception;

        void Handle();
    }
}

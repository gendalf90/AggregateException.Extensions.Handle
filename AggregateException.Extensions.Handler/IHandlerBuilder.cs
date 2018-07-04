using System;

namespace AggregateExceptionExtensions.Handler
{
    public interface IHandlerBuilder
    {
        IHandlerBuilder Empty<T>() where T : Exception;

        IHandlerBuilder Action<T>(Action<T> action) where T : Exception;

        IHandlerBuilder Condition<T>(Func<T, bool> predicate) where T : Exception;

        void Handle();
    }
}

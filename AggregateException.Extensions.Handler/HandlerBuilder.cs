using System;

namespace AggregateExceptionExtensions.Handler
{
    internal class HandlerBuilder : IHandlerBuilder
    {
        private readonly ChainHandler chainHandler = new ChainHandler();
        private readonly AggregateException exception;

        public HandlerBuilder(AggregateException exception)
        {
            this.exception = exception;
        }

        public void Handle()
        {
            exception.Handle(chainHandler.TryHandle);
        }

        public IHandlerBuilder Ignore<T>() where T : Exception
        {
            var handler = new TypedHandler<T>();
            chainHandler.AddHandler(handler);
            return this;
        }

        public IHandlerBuilder Action<T>(Action<T> action) where T : Exception
        {
            var handler = new TypedHandlerWithAction<T>(action);
            chainHandler.AddHandler(handler);
            return this;
        }

        public IHandlerBuilder Predicate<T>(Func<T, bool> predicate) where T : Exception
        {
            var handler = new TypedHandlerWithPredicate<T>(predicate);
            chainHandler.AddHandler(handler);
            return this;
        }
    }
}

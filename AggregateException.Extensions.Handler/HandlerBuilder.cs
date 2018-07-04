using System;

namespace AggregateExceptionExtensions.Handler
{
    internal class HandlerBuilder : IHandlerBuilder
    {
        private readonly ChainHandler chainHandler = new ChainHandler();
        private readonly AggregateException aggregateException;

        public HandlerBuilder(AggregateException aggregateException)
        {
            this.aggregateException = aggregateException;
        }

        public void Handle()
        {
            aggregateException.Handle(chainHandler.TryHandle);
        }

        public IHandlerBuilder Empty<T>() where T : Exception
        {
            var handler = new TypedEmptyHandler<T>();
            chainHandler.AddHandler(handler);
            return this;
        }

        public IHandlerBuilder Action<T>(Action<T> action) where T : Exception
        {
            if(action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var handler = new TypedHandlerWithAction<T>(action);
            chainHandler.AddHandler(handler);
            return this;
        }

        public IHandlerBuilder Condition<T>(Func<T, bool> predicate) where T : Exception
        {
            if(predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var handler = new TypedHandlerWithPredicate<T>(predicate);
            chainHandler.AddHandler(handler);
            return this;
        }
    }
}

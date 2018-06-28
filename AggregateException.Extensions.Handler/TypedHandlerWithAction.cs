using System;

namespace AggregateExceptionExtensions.Handler
{
    internal class TypedHandlerWithAction<T> : TypedHandler<T> where T : Exception
    {
        private readonly Action<T> action;

        public TypedHandlerWithAction(Action<T> action)
        {
            this.action = action;
        }

        protected override bool TryHandleInternal(T exception)
        {
            action(exception);
            return true;
        }
    }
}

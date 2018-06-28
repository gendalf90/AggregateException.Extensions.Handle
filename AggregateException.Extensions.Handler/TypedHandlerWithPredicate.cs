using System;

namespace AggregateExceptionExtensions.Handler
{
    internal class TypedHandlerWithPredicate<T> : TypedHandler<T> where T : Exception
    {
        private readonly Func<T, bool> predicate;

        public TypedHandlerWithPredicate(Func<T, bool> predicate)
        {
            this.predicate = predicate;
        }

        protected override bool TryHandleInternal(T exception)
        {
            return predicate(exception);
        }
    }
}

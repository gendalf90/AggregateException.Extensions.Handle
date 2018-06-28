using System;

namespace AggregateExceptionExtensions.Handler
{
    internal class TypedHandler<T> : TypedHandlerBase<T> where T : Exception
    {
        protected override bool TryHandleInternal(T exception)
        {
            return true;
        }
    }
}

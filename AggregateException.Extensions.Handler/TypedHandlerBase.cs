using System;

namespace AggregateExceptionExtensions.Handler
{
    internal abstract class TypedHandlerBase<T> : IHandler where T : Exception
    {
        public bool TryHandle(Exception exception)
        {
            var exceptionOfCurrentType = exception as T;

            if (exceptionOfCurrentType != null)
            {
                return TryHandleInternal(exceptionOfCurrentType);
            }

            return false;
        }

        protected abstract bool TryHandleInternal(T exception);
    }
}

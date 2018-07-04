using System;

namespace AggregateExceptionExtensions.Handler
{
    public static class AggregateExceptionExtensions
    {
        public static IHandlerBuilder AddHandlers(this AggregateException aggregateException)
        {
            if(aggregateException == null)
            {
                throw new ArgumentNullException(nameof(aggregateException));
            }

            return new HandlerBuilder(aggregateException);
        }
    }
}

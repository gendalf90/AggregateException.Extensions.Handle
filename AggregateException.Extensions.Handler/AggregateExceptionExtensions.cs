using System;

namespace AggregateExceptionExtensions.Handler
{
    public static class AggregateExceptionExtensions
    {
        public static IHandlerBuilder AddHandlers(this AggregateException exception)
        {
            return new HandlerBuilder(exception);
        }
    }
}

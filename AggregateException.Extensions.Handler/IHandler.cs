using System;

namespace AggregateExceptionExtensions.Handler
{
    internal interface IHandler
    {
        bool TryHandle(Exception exception);
    }
}

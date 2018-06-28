using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregateExceptionExtensions.Handler
{
    internal class ChainHandler : IHandler
    {
        private readonly List<IHandler> handlers;

        public ChainHandler()
        {
            handlers = new List<IHandler>();
        }

        public void AddHandler(IHandler handler)
        {
            handlers.Add(handler);
        }

        public bool TryHandle(Exception exception)
        {
            return handlers.Any(handler => handler.TryHandle(exception));
        }
    }
}

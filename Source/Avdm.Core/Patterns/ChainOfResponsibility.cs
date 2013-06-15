using System.Collections.Generic;

namespace Avdm.Core.Patterns
{
    public class ChainOfResponsibility<TClient, TData>
        where TClient : class
    {
        private readonly List<IChainOfResponsibilityHandler<TClient, TData>> m_handlers = new List<IChainOfResponsibilityHandler<TClient, TData>>();
        private readonly TClient m_client;

        public ChainOfResponsibility( TClient client )
        {
            Preconditions.CheckNotNull( client, "client" );

            m_client = client;
        }

        public void AddHandler( IChainOfResponsibilityHandler<TClient, TData> handler )
        {
            Preconditions.CheckNotNull( handler, "handler" );

            m_handlers.Add( handler );
        }

        public bool Handle( TData data )
        {
            bool wasHandled = false;

            //Use dynamics to get multiple dispatch. I.e. call the method taking the most derived parameter
            // Not doing this would give us virtual dispatch and only the method implementing the interface would get called
            foreach( dynamic handler in m_handlers )
            {
                wasHandled |= handler.Handle( m_client, (dynamic)data, wasHandled );
            }

            return wasHandled;
        }
    }
}
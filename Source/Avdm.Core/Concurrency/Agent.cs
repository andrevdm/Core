using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Avdm.Core.Concurrency
{
    public class Agent<T> : IDisposable
    {
        private readonly T m_data;
        private BlockingCollection<Tuple<Func<T, object>, Action<object, Exception>>> m_actions = new BlockingCollection<Tuple<Func<T, object>, Action<object, Exception>>>( new ConcurrentQueue<Tuple<Func<T, object>, Action<object, Exception>>>() );

        public Agent( T data )
        {
            m_data = data;
            Task.Factory.StartNew( ProcessActions );
        }

        public Task Act( Action<T> act )
        {
            return Act( data =>
                {
                    act( data );
                    return true;
                } );
        }

        public Task<TResult> Act<TResult>( Func<T, TResult> func )
        {
            var taskSource = new TaskCompletionSource<TResult>();

            if( func != null )
            {
                m_actions.Add( new Tuple<Func<T, object>, Action<object, Exception>>(
                    data => func( data ),
                    ( result, ex ) =>
                    {
                        if( ex != null )
                        {
                            taskSource.SetException( ex );
                        }
                        else
                        {
                            taskSource.SetResult( (TResult)result );
                        }
                    } ) );

                return taskSource.Task;
            }
            else
            {
                taskSource.SetResult( default( TResult ) );
                return taskSource.Task;
            }
        }

        private void ProcessActions()
        {
            foreach( Tuple<Func<T, object>, Action<object, Exception>> action in m_actions.GetConsumingEnumerable() )
            {
                try
                {
                    object result = action.Item1( m_data );
                    action.Item2( result, null );
                }
                catch( Exception ex )
                {
                    action.Item2( null, ex );
                }
            }
        }

        ~Agent()
        {
            Dispose( false );
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( Boolean disposing )
        {
            if( disposing )
            {
                if( m_actions != null )
                {
                    m_actions.CompleteAdding();
                    m_actions.Dispose();
                    m_actions = null;
                }
            }
        }
    }

    public class Agent : IDisposable
    {
        private readonly Agent<bool> m_agent = new Agent<bool>( true );

        public Task Act( Action act )
        {
            return m_agent.Act( _ => act() );
        }

        ~Agent()
        {
            Dispose( false );
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( Boolean disposing )
        {
            if( disposing )
            {
                m_agent.Dispose();
            }
        }
    }
}

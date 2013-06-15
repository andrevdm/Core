/*using System;

namespace Avdm.Core.Caching
{
    public class NetTpSharedCache : ICache
    {
        public void Set( string key, object value )
        {
            try
            {
                IndexusDistributionCache.SharedCache.Add( key, value );
            }
            catch( Exception ex )
            {
                try
                {
                    Log.Error( "Shared cache exception", ex );
                    IndexusDistributionCache.SharedCache.Remove( key );
                }
                catch
                {
                }
            }
        }

        public void Set( string key, object value, TimeSpan validFor )
        {
            try
            {
                IndexusDistributionCache.SharedCache.Add( key, value, DateTime.Now.AddSeconds( validFor.TotalSeconds ) );
            }
            catch( Exception ex )
            {
                try
                {
                    Log.Error( "Shared cache exception", ex );
                    IndexusDistributionCache.SharedCache.Remove( key );
                }
                catch
                {
                }
            }
        }

        public void Set( string key, object value, DateTime expiresAt )
        {
            try
            {
                IndexusDistributionCache.SharedCache.Add( key, value, expiresAt );
            }
            catch( Exception ex )
            {
                try
                {
                    Log.Error( "Shared cache exception", ex );
                    IndexusDistributionCache.SharedCache.Remove( key );
                }
                catch
                {
                }
            }
        }

        public object Get( string key )
        {
            try
            {
                return IndexusDistributionCache.SharedCache.Get( key );
            }
            catch( Exception ex )
            {
                try
                {
                    Log.Error( "Shared cache exception", ex );
                    IndexusDistributionCache.SharedCache.Remove( key );
                }
                catch
                {
                }
            }

            return null;
        }

        public void Remove( string key )
        {
            IndexusDistributionCache.SharedCache.Remove( key );
        }

        public object this[string key]
        {
            get { return Get( key ); }
            set { Set( key, value ); }
        }
    }
}
*/
using System;
using System.Web;
using System.Web.Caching;

namespace Avdm.Core.Caching
{
    public class HttpCache : ICache
    {
        public void Set( string key, object value )
        {
            HttpRuntime.Cache.Add( key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null );
        }

        public void Set( string key, object value, TimeSpan validFor )
        {
            HttpRuntime.Cache.Add( key, value, null, DateTime.Now.Add( validFor ), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null );
        }

        public void Set( string key, object value, DateTime expiresAt )
        {
            HttpRuntime.Cache.Add( key, value, null, expiresAt, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null );
        }

        public object Get( string key )
        {
            return HttpRuntime.Cache.Get( key );
        }

        public void Remove( string key )
        {
            HttpRuntime.Cache.Remove( key );
        }


        public object this[string key]
        {
            get { return Get( key ); }
            set { Set( key, value ); }
        }
    }
}

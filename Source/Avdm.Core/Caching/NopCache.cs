using System;

namespace Avdm.Core.Caching
{
    public class NopCache : ICache
    {
        public void Set( string key, object value )
        {
        }

        public void Set( string key, object value, TimeSpan validFor )
        {
        }

        public void Set( string key, object value, DateTime expiresAt )
        {
        }

        public object Get( string key )
        {
            return null;
        }

        public void Remove( string key )
        {
        }


        public object this[string key]
        {
            get { return null; }
            set { }
        }
    }
}

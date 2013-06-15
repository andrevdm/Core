using System;

namespace Avdm.Core.Caching
{
    public interface ICache
    {
        void Set( string key, object value );
        void Set( string key, object value, TimeSpan validFor );
        void Set( string key, object value, DateTime expiresAt );
        object Get( string key );
        void Remove( string key );

        object this[string key] { get; set; }
    }
}

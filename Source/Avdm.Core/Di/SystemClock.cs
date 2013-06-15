using System;
using System.Threading;

namespace Avdm.Core.Di
{
    /// <summary>
    /// An implenetation of IClock using the actual system clock
    /// </summary>
    public class SystemClock : IClock
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        public void ThreadSleep( int wait )
        {
            Thread.Sleep( wait );
        }

        public void ThreadSleep( TimeSpan wait )
        {
            Thread.Sleep( wait );
        }
    }
}

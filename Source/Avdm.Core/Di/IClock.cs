using System;

namespace Avdm.Core.Di
{
    /// <summary>
    /// Interface used to make unit testing time based opperations possible
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// The current time
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// Pause the current thread 
        /// </summary>
        /// <param name="wait"></param>
        void ThreadSleep( TimeSpan wait );

        /// <summary>
        /// Pause the current thread 
        /// </summary>
        /// <param name="wait"></param>
        void ThreadSleep( int wait );
    }
}

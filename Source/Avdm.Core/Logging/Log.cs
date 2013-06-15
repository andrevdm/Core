using System;
using log4net;

namespace Avdm.Core.Logging
{
    public static class Log
    {
        private static readonly ILog g_log;

        static Log()
        {
            log4net.Config.XmlConfigurator.Configure();
            g_log = LogManager.GetLogger( typeof( Log ) );
        }

        public static ILog LogInstance { get { return g_log; } }

        public static bool IsDebugEnabled { get { return g_log.IsDebugEnabled; } }
        public static bool IsErrorEnabled { get { return g_log.IsErrorEnabled; } }
        public static bool IsFatalEnabled { get { return g_log.IsFatalEnabled; } }
        public static bool IsInfoEnabled { get { return g_log.IsInfoEnabled; } }
        public static bool IsWarnEnabled { get { return g_log.IsWarnEnabled; } }

        public static void Debug( object message )
        {
            g_log.Debug( message );
        }

        public static void Debug( object message, Exception exception )
        {
            g_log.Debug( message, exception );
        }

        public static void DebugFormat( string format, object arg0 )
        {
            g_log.DebugFormat( format, arg0 );
        }

        public static void DebugFormat( string format, params object[] args )
        {
            g_log.DebugFormat( format, args );
        }

        public static void DebugFormat( IFormatProvider provider, string format, params object[] args )
        {
            g_log.DebugFormat( provider, format, args );
        }

        public static void DebugFormat( string format, object arg0, object arg1 )
        {
            g_log.DebugFormat( format, arg0, arg1 );
        }

        public static void DebugFormat( string format, object arg0, object arg1, object arg2 )
        {
            g_log.DebugFormat( format, arg0, arg1, arg2 );
        }

        public static void Error( object message )
        {
            g_log.Error( message );
        }

        public static void Error( object message, Exception exception )
        {
            g_log.Error( message, exception );
        }

        public static void ErrorFormat( string format, object arg0 )
        {
            g_log.ErrorFormat( format, arg0 );
        }

        public static void ErrorFormat( string format, params object[] args )
        {
            g_log.ErrorFormat( format, args );
        }

        public static void ErrorFormat( IFormatProvider provider, string format, params object[] args )
        {
            g_log.ErrorFormat( provider, format, args );
        }

        public static void ErrorFormat( string format, object arg0, object arg1 )
        {
            g_log.ErrorFormat( format, arg0, arg1 );
        }

        public static void ErrorFormat( string format, object arg0, object arg1, object arg2 )
        {
            g_log.ErrorFormat( format, arg0, arg1, arg2 );
        }

        public static void Error( Exception ex, string message )
        {
            g_log.Error( message, ex );
        }

        public static void Fatal( object message )
        {
            g_log.Fatal( message );
        }

        public static void Fatal( object message, Exception exception )
        {
            g_log.Fatal( message, exception );
        }

        public static void FatalFormat( string format, object arg0 )
        {
            g_log.FatalFormat( format, arg0 );
        }

        public static void FatalFormat( string format, params object[] args )
        {
            g_log.FatalFormat( format, args );
        }

        public static void FatalFormat( IFormatProvider provider, string format, params object[] args )
        {
            g_log.FatalFormat( provider, format, args );
        }

        public static void FatalFormat( string format, object arg0, object arg1 )
        {
            g_log.FatalFormat( format, arg0, arg1 );
        }

        public static void FatalFormat( string format, object arg0, object arg1, object arg2 )
        {
            g_log.FatalFormat( format, arg0, arg1, arg2 );
        }

        public static void Info( object message )
        {
            g_log.Info( message );
        }

        public static void Info( object message, Exception exception )
        {
            g_log.Info( message, exception );
        }

        public static void InfoFormat( string format, object arg0 )
        {
            g_log.InfoFormat( format, arg0 );
        }

        public static void InfoFormat( string format, params object[] args )
        {
            g_log.InfoFormat( format, args );
        }

        public static void InfoFormat( IFormatProvider provider, string format, params object[] args )
        {
            g_log.InfoFormat( provider, format, args );
        }

        public static void InfoFormat( string format, object arg0, object arg1 )
        {
            g_log.InfoFormat( format, arg0, arg1 );
        }

        public static void InfoFormat( string format, object arg0, object arg1, object arg2 )
        {
            g_log.InfoFormat( format, arg0, arg1, arg2 );
        }

        public static void Warn( object message )
        {
            g_log.Warn( message );
        }

        public static void Warn( object message, Exception exception )
        {
            g_log.Warn( message, exception );
        }

        public static void WarnFormat( string format, object arg0 )
        {
            g_log.WarnFormat( format, arg0 );
        }

        public static void WarnFormat( string format, params object[] args )
        {
            g_log.WarnFormat( format, args );
        }

        public static void WarnFormat( IFormatProvider provider, string format, params object[] args )
        {
            g_log.WarnFormat( provider, format, args );
        }

        public static void WarnFormat( string format, object arg0, object arg1 )
        {
            g_log.WarnFormat( format, arg0, arg1 );
        }

        public static void WarnFormat( string format, object arg0, object arg1, object arg2 )
        {
            g_log.WarnFormat( format, arg0, arg1, arg2 );
        }
    }

}

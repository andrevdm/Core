using System;

namespace Avdm.Core.Console
{
    /// <summary>
    /// Class that can load and execute a class that implements <see cref="IRunnable">IRunnable</see>.
    /// This is useful as it means that we can have a single stup (see <see cref="Avdm.AppRunnerStub">AppRunnerStub</see>)
    /// </summary>
    public class AppRunner
    {
        public int Run( IRunnable runnable, string[] args )
        {
            return runnable.Run( args );
        }

        public int Run( Type type, string[] args )
        {
            var runnable = (IRunnable)Activator.CreateInstance( type, true );
            return Run( runnable, args );
        }

        public int Run( string typeName, string[] args )
        {
            var type = Type.GetType( typeName, true );
            var runnable = (IRunnable)Activator.CreateInstance( type );
            return Run( runnable, args );
        }
    }
}

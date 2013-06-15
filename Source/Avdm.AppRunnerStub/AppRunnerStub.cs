using System;
using System.Linq;
using Avdm.Core.Console;

namespace Avdm.AppRunnerStub
{
    /// <summary>
    /// The AppRunnerStub is a stub used to load types that implement IRunnable.
    /// This means that you dont need to create seperate console projects just to run something.
    /// Rather you can have a single stub that loads items from other assemblies as required
    /// </summary>
    public class AppRunnerStub
    {
        static int Main( string[] args )
        {
            if( args.Length == 0 )
            {
                Console.WriteLine( "Invalid arguments" );
                Console.WriteLine( " arg[0] = full type name (IRunnable) to run" );
            }

            string typeName = args[0];
            var runner = new AppRunner();
            var result = runner.Run( typeName, args.Skip( 1 ).ToArray() );
            
            //TODO this should not be required but the TriadPrimary wont shutdown cleanly
            Environment.Exit( result );

            return result;
        }
    }
}

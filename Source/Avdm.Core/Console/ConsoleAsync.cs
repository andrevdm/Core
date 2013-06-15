using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avdm.Core.Concurrency;

namespace Avdm.Core.Console
{
    /// <summary>
    /// Utility class for writing to the console asychrnously.
    /// Useful to avoid slowing down an application becase of console writes.
    /// Also ensures that multipe writes are not interrupted by other writes / console colour changes
    /// </summary>
    public static class ConsoleAsync
    {
        private static readonly Agent g_agent = new Agent();

        public static void WriteLine( string format, params object[] args )
        {
            g_agent.Act( () => System.Console.WriteLine( format, args ) );
        }

        public static void WriteLine( ConsoleColor color, string format, params object[] args )
        {
            g_agent.Act( () =>
            {
                System.Console.ForegroundColor = color;
                System.Console.WriteLine( format, args );
                System.Console.ResetColor();
            } );
        }

        public static string ArrayToTextTable( List<object[]> items )
        {
            var header = items[0];
            string ruler = "";

            for( var col = 0; col < header.Length; ++col )
            {
                int colMax = (from r in items select r[col].ToString().Length).Max();

                ruler += "+--";
                ruler += new string( '-', colMax );

                foreach( var item in items )
                {
                    string format = "{0," + colMax + "}";
                    item[col] = string.Format( format, item[col] );
                }
            }

            ruler += "+";

            var str = new StringBuilder();
            str.AppendLine( ruler );

            for( int index = 0; index < items.Count; index++ )
            {
                var item = items[index];
                str.Append( "| " );

                for( int col = 0; col < item.Length; ++col )
                {
                    str.Append( item[col] );
                    str.Append( " | " );
                }

                str.AppendLine();

                if( index == 0 )
                {
                    str.AppendLine( ruler );
                }
            }

            str.AppendLine( ruler );
            return str.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Avdm.Core.TestApp
{
	public class ConsoleTestApp
	{
		private bool m_exit = false;
		private readonly string m_origTitle;
		private readonly Stopwatch m_actionTimer = new Stopwatch();
		private readonly Stopwatch m_subTaskTimer = new Stopwatch();
		private const string MenuChars = "abdefghijklmnoprstuvwxyz1234567890ABDEFGHIJKLMNOPRSTUVWXYZ!@#$%^&*-+=~;<>/?";

		public List<MenuItem> MenuItems { get; private set; }
		public bool Exit { get; set; }

		public ConsoleTestApp()
		{
			Action showTimes = ShowTimes;
			showTimes.BeginInvoke( null, null );

			//m_origTitle = Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().Location );
			//m_origTitle = Console.Title;

            try
            {
                m_origTitle = Path.GetFileName( System.Console.Title );
            }
            catch
            {
                m_origTitle = System.Console.Title;
            }

			System.Console.Title = m_origTitle;

			MenuItems = new List<MenuItem>
			              	{
			              		new MenuItem( "App", 'q', "Exit", SetExit ),
			              		new MenuItem( "App", 'c', "Cls", ClearScreen ),
			              	};
		}

		public virtual void Start()
		{
			while( !m_exit )
			{
				DisplayMenu();

				ConsoleKeyInfo key = System.Console.ReadKey( true );
				System.Console.WriteLine();

				char keyChar = key.KeyChar;

				var menuItem = MenuItems.Find( m => m.Key == keyChar );

				if( menuItem != null )
				{
					try
					{
						System.Console.ForegroundColor = ConsoleColor.Yellow;
						System.Console.WriteLine( "{0}. {1}...", keyChar, menuItem.Description );
						System.Console.ResetColor();
						System.Console.WriteLine();

						m_actionTimer.Reset();
						m_actionTimer.Start();
						menuItem.Action();
						m_actionTimer.Stop();
					}
					catch( Exception ex )
					{
						m_actionTimer.Stop();
						System.Console.ForegroundColor = ConsoleColor.Red;
						System.Console.WriteLine( ex.ToString() );
						System.Console.ResetColor();
					}
				}
				else
				{
					System.Console.WriteLine( "Unknown command '{0}'", keyChar );
				}

				System.Console.WriteLine();
			}
		}

		private void ClearScreen()
		{
			System.Console.Clear();
		}

		private void SetExit()
		{
			m_exit = true;
		}

		private void DisplayMenu()
		{
			System.Console.ForegroundColor = ConsoleColor.Cyan;

			try
			{
				System.Console.WriteLine( "+------------------------------------------------------------------------------+" );
				System.Console.WriteLine( "|   Version: {0}", GetType().Assembly.GetName().Version );
				PrintAdditionalInfo();
				System.Console.WriteLine( "|" );

				var groups = from menu in MenuItems
								 orderby menu.Category
								 group menu by menu.Category;

				int keyIndex = 0; ;

				foreach( var item in groups )
				{
					System.Console.Write( "| " );
					System.Console.ForegroundColor = ConsoleColor.Green;
					System.Console.WriteLine( " {0}", item.Key );
					System.Console.ForegroundColor = ConsoleColor.Cyan;


					foreach( MenuItem child in item )
					{
						if( (child.Key != 'q') && (child.Key != 'c') )
						{
							if( (MenuChars[keyIndex] == 'q') || (MenuChars[keyIndex] == 'c') )
							{
								keyIndex++;
							}

							if( keyIndex >= MenuChars.Length )
							{
								keyIndex = 0;
							}

							child.Key = MenuChars[keyIndex];
							keyIndex++;
						}

						System.Console.WriteLine( "|    '{0}'. {1}", child.Key, child.Description );
					}
				}

				System.Console.WriteLine( "+------------------------------------------------------------------------------+" );
			}
			finally
			{
				System.Console.ResetColor();
			}
		}

		protected virtual void PrintAdditionalInfo()
		{
		}

		protected string Prompt( string prompt )
		{
			System.Console.Write( prompt + "> " );
			return System.Console.ReadLine().Trim();
		}

		protected string PromptForPassword( string prompt )
		{
			System.Console.Write( prompt + "> " );
			
			string password = "";

			ConsoleKeyInfo info = System.Console.ReadKey( true );

			while( info.Key != ConsoleKey.Enter )
			{
				switch( info.Key )
				{
					case ConsoleKey.Backspace:
						if( !string.IsNullOrEmpty( password ) )
						{
							password = password.Substring( 0, password.Length - 1 );

							System.Console.SetCursorPosition( System.Console.CursorLeft - 1, System.Console.CursorTop );
							System.Console.Write( " " );
							System.Console.SetCursorPosition( System.Console.CursorLeft - 1, System.Console.CursorTop );
						}
						break;

					default:
						password += info.KeyChar;
						System.Console.Write( "*" );
						break;
				}

				info = System.Console.ReadKey( true );
			}

			System.Console.WriteLine();
			return password;
		}	

		protected TimeSpan Time( Action action, string name )
		{
			m_subTaskTimer.Reset();
			m_subTaskTimer.Start();

			try
			{
				System.Console.WriteLine( "   starting {0}...", name );
				var stopwatch = new Stopwatch();
				stopwatch.Start();
				action();
				stopwatch.Stop();
				System.Console.WriteLine( "   finished {0} in {1}", name, stopwatch.Elapsed );
            return stopwatch.Elapsed;
			}
			finally 
			{
				m_subTaskTimer.Stop();
			}
		}

		private void ShowTimes()
		{
			int i = 0;

			while( !m_exit )
			{
				char current = ' ';

				switch( i % 4 )
				{
					case 0:
						current = '|';
						break;
					case 1:
						current = '/';
						break;
					case 2:
						current = '-';
						break;
					case 3:
						current = '\\';
						i = 0;
						break;
				}

				string title = m_origTitle;

				if( m_actionTimer.IsRunning )
				{
					title += string.Format( " - action={0}", FormatTimespan( m_actionTimer.Elapsed ) );

					if( m_subTaskTimer.IsRunning )
					{
						title += string.Format( ", subTask={0}", FormatTimespan( m_subTaskTimer.Elapsed ) );
					}
					
					title = string.Format( "{0} {1}", title, current );
				}

				System.Console.Title = title ?? "";

				i++;
				Thread.Sleep( 200 );
			}

		}
		
		protected string FormatTimespan( TimeSpan ts )
		{
			return string.Format( "{0:D2}:{1:D2}:{2:D3}", ts.Minutes, ts.Seconds, ts.Milliseconds );
		}
	}
}

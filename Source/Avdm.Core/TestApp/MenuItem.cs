using System;

namespace Avdm.Core.TestApp
{
	public class MenuItem
	{
		public MenuItem( string category, string description, Action action )
			: this( category, '\0', description, action )
		{
		}

		public MenuItem( string category, char key, string description, Action action )
		{
			Category = category;
			Key = key;
			Description = description;
			Action = action;
		}

		public string Category { get; set; }
		public char Key { get; set; }
		public string Description { get; set; }
		public Action Action { get; set; }
	}
}
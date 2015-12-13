using System;
using System.Collections.Generic;

namespace EventStreamFx.DynamicEvent
{
	public class DynamicEventDefinition
	{
		private Dictionary<int, DynamicDefinition> definitions = new Dictionary<int, DynamicDefinition>();

		public void Register()
		{
			definitions.Add(1, new DynamicDefinition("SignupCreated", "Name", "Age"));
		}

		internal bool Contains(int typeid)
		{
			return definitions.ContainsKey(typeid);
		}

		internal DynamicDefinition this[int typeid] => this.definitions[typeid];
	}
}
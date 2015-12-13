using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EventStreamFx.Core;

namespace EventStreamFx.DynamicEvent
{
	public class DynamicReader : IEventStoreReader
	{
		private readonly DynamicEventDefinition definitions;
		
		public DynamicReader(DynamicEventDefinition definitions)
		{
			this.definitions = definitions;
		}

		private dynamic Read(Stack<object> data)
		{
			if (data.Count < 1)
			{
				throw new Exception("Missing properties");
			}

			dynamic e = new DynamicEvent();

			var typeid = (int)data.Pop();

			if (!definitions.Contains(typeid))
			{
				throw new Exception("Invalid EventType: " + typeid);
			}

			var def = definitions[typeid];

			var id = data.Pop();

			e.Id = id;
			e.EventId = (Guid)data.Pop();
			e.Timestamp = (DateTime)data.Pop();

			foreach (var property in def.Properties)
			{
				e[property] = data.Pop();
			}

			return e;
		}

		public Task<IEventSteam> ReadStream(string identifier, long version, long take)
		{
			throw new NotImplementedException();
		}

		public Task<IEventSteam> ReadStream(long version, long take)
		{
			throw new NotImplementedException();
		}
	}
}
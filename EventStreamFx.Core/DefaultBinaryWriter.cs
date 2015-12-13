using System;
using System.Collections.Generic;
using System.IO;
using EventStreamFx.Core.Binary;

namespace EventStreamFx.Core
{
	public interface IEventMeta
	{
		string EventTypeName { get; }

		int EventVersion { get; }

		Dictionary<int,Type> Properties { get; }
		
		IEventData Set(Dictionary<int, object> data);
		Dictionary<int, object> Get(IEventData data);
	}

	public interface IEventProperty
	{
		Type Type { get; }
	}

	public interface IEventDescriptionProvider
	{
		IEventMeta GetEventByTypename(object typename);
		IEventMeta GetEvent<T>(T data);
	}
}
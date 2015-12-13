using System;
using System.Threading.Tasks;

namespace EventStreamFx.Core
{
	public interface IEventStoreWriter
	{
		Task AppendStream(string identifier, long expectedVersion, object stream);
	}

	public interface IEventStoreReader
	{
		Task<IEventSteam> ReadStream(string identifier, long version, long take);

		Task<IEventSteam> ReadStream(long version, long take);
	}

	public interface IEventSteam
	{
		int Version { get; }

		IEventData[] Events { get; }
	}

	public interface IEventData
	{
		object TypeName { get; }

		object Id { get; }
		
		Guid EventId { get; }

		DateTime Timestamp { get; }
	}
}
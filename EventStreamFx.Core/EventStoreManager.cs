using System.Threading.Tasks;

namespace EventStreamFx.Core
{
	public class EventStoreManager : IEventStoreReader, IEventStoreWriter
	{
		private readonly IEventStoreReader reader;
		private readonly IEventStoreWriter writer;

		public EventStoreManager(IEventStoreReader reader, IEventStoreWriter writer)
		{
			this.reader = reader;
			this.writer = writer;
		}

		public Task<IEventSteam> ReadStream(string identifier, long version, long take)
		{
			return reader.ReadStream(identifier, version, take);
		}

		public Task<IEventSteam> ReadStream(long version, long take)
		{
			return reader.ReadStream(version, take);
		}

		public Task AppendStream(string identifier, long expectedVersion, IEventData[] events)
		{
			return writer.AppendStream(identifier, expectedVersion, events);
		}

		public Task AppendStream(string identifier, long expectedVersion, object stream)
		{
			return writer.AppendStream(identifier, expectedVersion, stream);
		}
	}
}
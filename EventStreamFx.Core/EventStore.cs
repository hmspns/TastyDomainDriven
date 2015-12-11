using System.Collections;
using System.Threading.Tasks;

namespace EventStreamFx.Core
{
	public class EventStore
	{
		public Task<IDataStream> ReadStream(string identifier, long version, long take)
		{
			return null;
		}

		public Task AppendStream(string identifier, long expectedVersion, IEventStream stream)
		{
			return null;
		}

		public Task<IDataStream> ReadStream(long version, long take)
		{
			return null;
		}
	}

	public interface IEventStream : IEnumerable
	{
	}

	public interface IDataStream
	{
		Task Read();
	}
}
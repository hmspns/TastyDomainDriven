using System.IO;

namespace EventStreamFx.Core.Binary
{
	internal class BinaryEventStreamWriter
	{
		private readonly BinaryWriter writer;

		private BinaryEventStreamWriter(BinaryWriter writer)
		{
			this.writer = writer;
		}

		internal void WriteEvents(IEventData[] events)
		{
			IEventDescriptionProvider descriptionProvider = null;
			writer.Write(events.Length);

			foreach (var data in events)
			{
				var meta = descriptionProvider.GetEvent(data);
				var values = meta.Get(data);

				foreach (var o in values)
				{
					writer.Write(o.Key);
					BinaryPrimatives.Writes[o.GetType()](writer, o.Value);
				}
			}
		}
	}
}
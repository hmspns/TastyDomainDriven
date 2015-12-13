using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace EventStreamFx.Core.Binary
{
	internal class BinaryEventStreamReader
	{
		private readonly BinaryReader reader;
		private readonly IEventDescriptionProvider descriptionProvider;

		public BinaryEventStreamReader(BinaryReader reader, IEventDescriptionProvider descriptionProvider)
		{
			this.reader = reader;
			this.descriptionProvider = descriptionProvider;
		}

		private Task<IEventData[]> ReadEvents()
		{
			IEventDescriptionProvider descriptionProvider = null;

			var eventToRead = reader.ReadUInt16();
			//Should read checksum, to verify complete write here

			List<IEventData> events = new List<IEventData>();

			for (int i = 0; i < eventToRead; i++)
			{				
				var info = descriptionProvider.GetEvent(reader.ReadInt32());

				var values = new Dictionary<int, object>();
				var pos = reader.ReadInt32();
				values[pos] = BinaryPrimatives.Reads[info.Properties[pos]](reader);
				events.Add(info.Set(values));
			}

			

			return Task.FromResult(events.ToArray());
		}
	}
}
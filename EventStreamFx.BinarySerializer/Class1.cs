using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace EventStreamFx.BinarySerializer
{

	public class BinaryEventReader
	{
#if DNXCORE54
		private BinaryFormatter serializer = new BinaryFormatter();

		public Task Write(IEventData data)
		{

		}

#endif
	}
}

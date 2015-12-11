using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventStreamFx.Core;

namespace EventStreamFx.SampleDemo.Events
{
	public class FileDiscoveredEvent
	{
		public FileDiscoveredEvent(Stack<object> properties)
		{
			this.Checksum = (string) properties.Pop();
			this.Filename = (string) properties.Pop();
			this.Filesize = (long) properties.Pop();
		}

		public Stack<object> Write()
		{
			var s = new Stack<object>();
			s.Push(this.Checksum);
			s.Push(this.Filename);
			s.Push(this.Filesize);
			return s;
		}

		public string Checksum { get; private set; }

		public string Filename { get; private set; }

		public long Filesize { get; private set; }
	}

	public class FileDiscoveredEventStack : Stack<object>
	{
		public FileDiscoveredEventStack() : base(4)
		{
		}

		
	}
}
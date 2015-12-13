using EventStreamFx.SampleDemo.Events;

namespace EventStreamFx.SampleDemo
{
	public class EventLibrary
	{
		 public EventLibrary()
		 {
			this.Register("FileDiscoveredEvent", new NormalSerializer(typeof(FileDiscoveredEvent)));
		 }

		public class NormalSerializer
		{
			
		}

		public void Register(object typename, object resolver)
		{
			
		}
	}
}
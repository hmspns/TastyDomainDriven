using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStreamFx.SampleDemo.Events;

namespace EventStreamFx.SampleDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var e = new FileDiscoveredEvent();
			Console.Write(e.ToString());
	        Console.ReadKey(true);
        }
    }
}

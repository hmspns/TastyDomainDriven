using System;
using System.Collections.Generic;
using System.IO;

namespace EventStreamFx.Core.Binary
{
	internal static class BinaryPrimatives
	{
		internal static Dictionary<Type, Action<BinaryWriter, object>>  Writes = new Dictionary<Type, Action<BinaryWriter, object>>();
		
		internal static Dictionary<Type, Func<BinaryReader, object>>  Reads = new Dictionary<Type, Func<BinaryReader, object>>();

		static BinaryPrimatives()
		{
			Writes[typeof (string)] = (writer, o) => writer.Write((string) o);
			Writes[typeof (int)] = (writer, o) => writer.Write((int) o);

			Reads[typeof (string)] = reader => reader.ReadString();
			Reads[typeof (int)] = reader => reader.ReadInt32();
		}
	}
}
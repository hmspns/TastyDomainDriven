namespace EventStreamFx.DynamicEvent
{
	internal class DynamicDefinition
	{
		public DynamicDefinition(string typeName, params string[] props)
		{
			this.TypeName = typeName;
			this.Properties = props;
		}

		public string TypeName { get; set; }

		public string[] Properties { get; set; }
	}
}
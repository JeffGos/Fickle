﻿namespace Fickle
{
	public class CodeGenerationOptions
	{
		public static readonly CodeGenerationOptions Default = new CodeGenerationOptions();

		public string BaseGatewayTypeName { get; set; }
		public bool GenerateClasses { get; set; }
		public bool GenerateEnums { get; set; }
		public bool GenerateGateways { get; set; }
		public bool SerializeEnumsAsStrings { get; set; }
		public string ServiceClientTypeName { get; set; }
		public string ResponseStatusTypeName { get; set; }
		public string ResponseStatusPropertyName { get; set; }
		public string TypeNamePrefix { get; set; }
		public string Namespace { get; set; }
		public ServiceModelInfo ServiceModelInfo { get; set; }

		public CodeGenerationOptions()
		{
			this.GenerateClasses = true;
			this.GenerateGateways = true;
			this.GenerateEnums = true;
			this.ResponseStatusTypeName = "ResponseStatus";
			this.ResponseStatusPropertyName = "ResponseStatus";

			this.ServiceModelInfo = new ServiceModelInfo
			{
				Name = "ServiceModel",
				Author = "Fickle",
				Summary = "Autogenerated by Fickle",
				Version = "1.0.0"
			};
		}
	}
}

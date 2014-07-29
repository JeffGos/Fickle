﻿using System.IO;

namespace Dryice.Generators.Objective
{
	public class PodspecWriter
		: SourceCodeGenerator
	{
		public PodspecWriter(TextWriter writer)
			: base(writer)
		{
		}

		public virtual void Write(ServiceModelInfo serviceModelInfo)
		{
			this.WriteLine(@"Pod::Spec.new do |s|");

			using (this.AcquireIndentationContext())
			{
				this.WriteLine("s.name = '{0}'", serviceModelInfo.Name);
				this.WriteLine("s.version = '{0}'", serviceModelInfo.Version);
				this.WriteLine("s.summary = '{0}'", serviceModelInfo.Summary);
				this.WriteLine("s.author = '{0}'", serviceModelInfo.Author);
				this.WriteLine("s.ios.deployment_target = '5.1'");
				this.WriteLine("s.osx.deployment_target = '10.7'");
				this.WriteLine("s.requires_arc = true");
				this.WriteLine("s.frameworks = 'CFNetwork', 'SystemConfiguration'");
				this.WriteLine(@"s.source_files = '**/*.{h,m}'");
			}

			this.WriteLine(@"end");
		}
	}
}
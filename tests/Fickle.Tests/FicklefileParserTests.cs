﻿using System;
using System.IO;
using System.Reflection;
using Fickle.Ficklefile;
using NUnit.Framework;
using Fickle.Model;

namespace Fickle.Tests
{
	[TestFixture]
	public class FicklefileParserTests
	{
		internal static ServiceModel GetTestServiceModel()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = typeof(FicklefileParserTests).Namespace + ".TestFiles.Test.fickle";

			using (var stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (var reader = new StreamReader(stream))
				{
					return FicklefileParser.Parse(reader);
				}
			}
		}

		[Test]
		public void Test_Parse_And_Generate_ObjectiveC()
		{
			var serviceModel = FicklefileParserTests.GetTestServiceModel();
			var codeGenerator = ServiceModelCodeGenerator.GetCodeGenerator("objc", Console.Out, CodeGenerationOptions.Default);

			codeGenerator.Generate(serviceModel);
		}
	}
}

﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Platform.Xml.Serialization;
using Sublimate.Model;

namespace Sublimate.Tests
{
	[TestFixture]
	public class TestModel
	{
		[Test]
		public void TestCreateAndSaveModel()
		{	
			var serviceModel = new ServiceModel();

			var personType = new ServiceClass()
			{
				Name = "Person",
				Properties = new List<ServiceProperty>()
				{
					new ServiceProperty()
					{
						Name = "Name",
						TypeName = "String"
					},
					new ServiceProperty()
					{
						Name = "Age",
						TypeName = "Int"
					},
					new ServiceProperty()
					{
						Name = "Friend",
						TypeName = "Person"
					}
				}
			};

			var userGateway = new ServiceGateway()
			{
				Name = "Gateway",
				Methods = new List<ServiceMethod>()
				{
					new ServiceMethod()
					{
						Name = "AddUser"
					},
					new ServiceMethod()
					{
						Name = "GetUser",
						Parameters = new List<ServiceParameter>()
						{
							new ServiceParameter()
							{
								Name = "Id",
								TypeName = "Guid"
							}
						}
					}
				}
			};

			serviceModel.Classes = new List<ServiceClass>() { personType };
			serviceModel.Gateways = new List<ServiceGateway>() { userGateway };

			var serializer = XmlSerializer<ServiceModel>.New();

			var xml = serializer.SerializeToString(serviceModel);
			var deserialized = serializer.Deserialize(xml);

			Assert.AreEqual(xml, serializer.SerializeToString(deserialized));

			Console.WriteLine(xml);
		}
	}
}

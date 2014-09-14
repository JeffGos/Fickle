﻿using System;
using System.Reflection;

namespace Fickle
{
	public class DryParameterInfo
		: ParameterInfo
	{
		private readonly string name;
		private readonly Type parameterType;

		public override string Name { get { return name; } }
		public override Type ParameterType { get { return parameterType; } }

		public DryParameterInfo(Type parameterType, string name, bool isIn = false)
		{
			this.name = name;
			this.parameterType = parameterType;

			if (isIn)
			{
				this.AttrsImpl |= ParameterAttributes.In;
			}
		}
	}
}

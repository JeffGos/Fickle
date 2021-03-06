﻿using System;
using System.Globalization;
using System.Reflection;

namespace Fickle
{
	public class FickleMethodInfo
		: MethodInfo
	{
		private readonly string name;
		private readonly Type returnType;
		private readonly Type declaringType;
		private readonly ParameterInfo[] parameters; 
		private readonly MethodAttributes methodAttributes;

		public override string Name { get { return name; } }
		public override Type ReturnType { get { return returnType; } }
		public override Type DeclaringType { get { return declaringType; } }
		public override Type ReflectedType { get { return declaringType; } }
		public override MethodAttributes Attributes { get { return methodAttributes; } }

		public FickleMethodInfo(Type declaringType, Type returnType, string name, ParameterInfo[] parameters, bool isStatic = false)
		{
			this.name = name;
			this.returnType = returnType;
			this.declaringType = declaringType;
			this.parameters = parameters;
			this.methodAttributes = MethodAttributes.Public;

			if (isStatic)
			{
				this.methodAttributes |= MethodAttributes.Static;
			}
		}

		public override ParameterInfo[] GetParameters()
		{
			return (ParameterInfo[])this.parameters.Clone();
		}

		public override string ToString()
		{
			return "FickleMethodInfo: " + this.Name;
		}

		#region Unimplemented

		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			throw new NotImplementedException();
		}

		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public override MethodInfo GetBaseDefinition()
		{
			throw new NotImplementedException();
		}

		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}

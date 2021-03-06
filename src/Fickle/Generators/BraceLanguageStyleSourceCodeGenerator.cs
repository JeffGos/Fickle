﻿//
// Copyright (c) 2013-2014 Thong Nguyen (tumtumtum@gmail.com)
//

using System;
using System.IO;
using System.Linq.Expressions;
using Fickle.Expressions;

namespace Fickle.Generators
{
	public class BraceLanguageStyleSourceCodeGenerator
		: SourceCodeGenerator
	{
		protected class CStyleIndentationContext
			: IDisposable
		{
			private readonly SourceCodeGenerator generator;
			private readonly BraceLanguageStyleIndentationOptions options;

			public CStyleIndentationContext(SourceCodeGenerator generator, BraceLanguageStyleIndentationOptions options)
			{
				this.generator = generator;
				this.options = options;

				if ((options & BraceLanguageStyleIndentationOptions.IncludeBraces) != 0)
				{
					generator.WriteLine("{");
				}

				this.generator.CurrentIndent++;
			}

			public virtual void Dispose()
			{
				this.generator.CurrentIndent--;

				if ((this.options & BraceLanguageStyleIndentationOptions.IncludeBraces) != 0)
				{
					this.generator.Write("}");
				}

				if ((this.options & BraceLanguageStyleIndentationOptions.NewLineAfter) != 0)
				{
					this.generator.WriteLine();
				}
			}
		}

		public BraceLanguageStyleSourceCodeGenerator(TextWriter writer)
			: base(writer)
		{
		}
			
		protected override Expression VisitCommentExpression(CommentExpression expression)
		{
			this.WriteLine("// " + expression.Comment);

			return expression;
		}

		public override IDisposable AcquireIndentationContext()
		{
			return this.AcquireIndentationContext(BraceLanguageStyleIndentationOptions.IncludeBracesNewLineAfter);
		}

		public virtual IDisposable AcquireIndentationContext(BraceLanguageStyleIndentationOptions options)
		{
			return new CStyleIndentationContext(this, options);
		}
	}
}

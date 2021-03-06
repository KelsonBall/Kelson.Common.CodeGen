﻿using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class BaseConstructorPrecall : ConstructorPrecall
    {
        public override IEnumerable<string> Prefix()
        {
            yield return $"base({string.Join(", ", Arguments)})";
        }

        public override IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public override IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

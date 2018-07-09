using System;
using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{    
    public class StaticImport : ISourceNode
    {        
        public Type Type { get; set; }
        
        public StaticImport()
        {

        }

        public StaticImport(Type type)
        {
            Type = type;
        }

        public IEnumerable<string> Prefix()
        {
            yield return $"using static {Type.Text()};";
        }

        public IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

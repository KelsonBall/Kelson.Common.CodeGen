using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public abstract class ConstructorPrecall : ISourceNode
    {
        public string[] Arguments { get; set; }

        public abstract IEnumerable<ISourceNode> Children();
        public abstract IEnumerable<string> Prefix();
        public abstract IEnumerable<string> Suffix();
    }
}

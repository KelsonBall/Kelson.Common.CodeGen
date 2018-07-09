using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public abstract class Argument : ISourceNode
    {
        public Type Type { get; set; }
        public string Name { get; set; }

        public abstract IEnumerable<ISourceNode> Children();
        public abstract IEnumerable<string> Prefix();
        public abstract IEnumerable<string> Suffix();
    }
}

using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public abstract class TypeDef : ISourceNode
    {
        public ReadModifier Access { get; set; }
        public string Name { get; set; }
        public string[] GenericParameters { get; set; }
        public BaseInterface[] BaseInterfaces { get; set; }

        public abstract IEnumerable<ISourceNode> Children();
        public abstract IEnumerable<string> Prefix();
        public abstract IEnumerable<string> Suffix();
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public class TypeAlias : ISourceNode
    {
        public string AliasName { get; set; }
        public Type Type { get; set; }

        public TypeAlias() { }

        public TypeAlias(string name, Type type)
        {
            AliasName = name;
            Type = type;
        }

        public IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public IEnumerable<string> Prefix()
        {
            yield return $"using {AliasName} = {Type.Text()};";
        }

        public IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

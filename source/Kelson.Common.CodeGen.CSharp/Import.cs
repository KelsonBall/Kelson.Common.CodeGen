using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public static class Imports
    {
        public static Import[] Of(params string[] imports) => imports.Select(i => new Import(i)).ToArray();
        public static StaticImport[] Statics(params Type[] imports) => imports.Select(i => new StaticImport(i)).ToArray();
        public static TypeAlias[] AliasesOf(params (string name, Type type)[] aliases) => aliases.Select(a => new TypeAlias(a.name, a.type)).ToArray();
    }

    public class Import : ISourceNode, IEnumerable<string>
    {        
        public string[] FullName { get; set; }

        public Import()
        {

        }

        public Import(string name)
        {
            FullName = name.Split('.');
        }

        public IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public IEnumerable<string> Prefix()
        {
            yield return $"using {string.Join(".", FullName)};";
        }

        public IEnumerable<string> Suffix()
        {
            yield break;
        }

        public void Add(params string[] names) => FullName = (FullName ?? new string[0]).Concat(names).ToArray();

        public IEnumerator<string> GetEnumerator() => FullName.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

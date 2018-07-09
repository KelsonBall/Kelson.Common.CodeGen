using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{    
    public class Header : ISourceNode
    {
        public Import[] Imports { get; set; }
        public StaticImport[] StaticImports { get; set; }
        public TypeAlias[] Aliases { get; set; }

        public IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public IEnumerable<string> Prefix()
        {
            foreach (var import in Imports.AsAll())
                yield return import.Text();
            foreach (var import in StaticImports.AsAll())
                yield return import.Text();
            foreach (var alias in Aliases.AsAll())
                yield return alias.Text();
        }

        public IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

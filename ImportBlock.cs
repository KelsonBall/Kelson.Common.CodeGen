using System;

namespace Kelson.CommonCodeGen
{
    public class ImportBlock : ISourceNode
    {
        public Import[] Imports { get; set; }
        public StaticImport[] StaticImports { get; set; }
        public TypeAlias[] Aliases { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

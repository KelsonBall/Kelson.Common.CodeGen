using System;

namespace Kelson.CommonCodeGen
{
    public class CodeFile : ISourceNode
    {
        public ImportBlock Header { get; set; }
        public Namespace[] Namespaces { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

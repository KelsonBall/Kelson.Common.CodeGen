using System;

namespace Kelson.CommonCodeGen
{
    public class Namespace : ISourceNode
    {
        public ImportBlock Header { get; set; }
        public Interface[] Interfaces { get; set; }
        public Class[] Classes { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

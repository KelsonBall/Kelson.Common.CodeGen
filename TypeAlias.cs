using System;

namespace Kelson.CommonCodeGen
{
    public class TypeAlias : ISourceNode
    {
        public string AliasName { get; set; }
        public TypeReference Type { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

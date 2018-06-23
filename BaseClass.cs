using System;

namespace Kelson.CommonCodeGen
{
    public class BaseClass : ISourceNode
    {
        public string Name { get; set; }
        public TypeReference[] GenericParameters { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

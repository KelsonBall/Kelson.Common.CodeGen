using System;

namespace Kelson.CommonCodeGen
{
    public class BaseInterface : ISourceNode
    {
        public string Name { get; set; }
        public TypeReference[] GenericParameters { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

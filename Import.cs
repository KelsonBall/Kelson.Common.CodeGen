using System;

namespace Kelson.CommonCodeGen
{
    public class Import : ISourceNode
    {        
        public string Name { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace Kelson.CommonCodeGen
{
    public class Statement : ISourceNode
    {
        public string Line { get; set; }

        public virtual string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

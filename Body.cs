using System;

namespace Kelson.CommonCodeGen
{
    public class Body : ISourceNode
    {
        public Statement[] Statements { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

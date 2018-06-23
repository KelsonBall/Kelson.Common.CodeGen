using System;
using System.IO;

namespace Kelson.CommonCodeGen
{
    public class SourceWriter
    {
        private readonly ISourceNode node;

        public SourceWriter(ISourceNode node)
        {
            this.node = node;
        }

        public void WriteTo(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}

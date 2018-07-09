using System;
using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Statement : ISourceNode
    {
        public string Line { get; set; }
        
        public Statement() { }
        public Statement(string line) => Line = line;


        public virtual IEnumerable<string> Prefix()
        {
            yield return Line;
        }

        public virtual IEnumerable<ISourceNode> Children()
        {
            yield break;
        }
        
        public virtual IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Body : ISourceNode
    {
        public Statement[] Statements { get; set; }

        public IEnumerable<ISourceNode> Children()
        { 
            foreach (var statement in Statements.AsAll())
                yield return statement;
        }

        public IEnumerable<string> Prefix()
        {
            yield break;
        }

        public IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

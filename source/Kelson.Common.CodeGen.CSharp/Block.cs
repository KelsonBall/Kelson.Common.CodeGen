using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Block : Statement
    {
        public Statement[] Statements { get; set; }

        public override IEnumerable<ISourceNode> Children()
        {            
            foreach (var statement in Statements.AsAll())
                yield return statement;
        }

        public override IEnumerable<string> Prefix()
        {
            yield return Line;
            yield return "{";            
        }

        public override IEnumerable<string> Suffix()
        {
            yield return "}";
        }
    }
}

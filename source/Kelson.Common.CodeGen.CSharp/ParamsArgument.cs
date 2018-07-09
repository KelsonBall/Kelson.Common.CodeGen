using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class ParamsArgument : Argument
    {
        public override IEnumerable<string> Prefix()
        {
            yield return $"{Type.Text()}[] {Name}";
        }

        public override IEnumerable<ISourceNode> Children()
        {
            yield break;
        }        

        public override IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

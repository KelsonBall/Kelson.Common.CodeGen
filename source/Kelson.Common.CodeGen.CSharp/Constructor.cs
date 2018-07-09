using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Constructor : ISourceNode
    {
        public ReadModifier Access { get; set; }
        internal string Name { get; set; }
        public Arg[] Arguments { get; set; }
        public ParamsArgument Params { get; set; }
        public ConstructorPrecall Precall { get; set; }
        public Body Body { get; set; }

        public IEnumerable<ISourceNode> Children()
        {
            foreach (var statement in Body?.Statements.AsAll())
                yield return statement;
        }

        public IEnumerable<string> Prefix()
        {
            var signature =
                new StringBuilder($"{Access.ToSource()} {Name}(")
                    .Append(string.Join(", ", Arguments.AsAll().SelectMany(a => a.Text())));
            if (Params != null)
                signature.Append(Params.Text());
            signature.Append(")");
            if (Precall != null)
                signature.Append(": ").Append(Precall.Text());

            yield return signature.ToString();
            yield return "{";
        }

        public IEnumerable<string> Suffix()
        {
            yield return "}";
        }
    }
}

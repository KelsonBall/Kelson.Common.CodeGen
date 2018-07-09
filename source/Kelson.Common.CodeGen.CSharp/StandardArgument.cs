using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public static class Args
    {
        public static Arg[] Of(params (Type type, string name)[] args) => args.Select(a => new Arg(a.type, a.name)).ToArray();
    }

    public class Arg : Argument
    {       
        public RefModifier RefType { get; set; }

        public Arg() { }

        public Arg(Type type, string name)
        {
            Type = type;
            Name = name;            
        }

        public Arg(RefModifier mod, Type type, string name) : this(type, name)
        {
            RefType = mod;
        }


        public override IEnumerable<string> Prefix()
        {
            yield return $"{RefType.ToSource(pad: true)}{Type.Text()} {Name}";
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

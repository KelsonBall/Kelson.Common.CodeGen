using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kelson.Common.CodeGen.CSharp
{    
    public class Method : Member
    {
        public string[] GenericParameters { get; set; }
        public Arg[] Arguments { get; set; }
        public ParamsArgument Params { get; set; }
        public Body Body { get; set; }

        private bool SignatureOnly => Inheritance == InheritanceModifier.Abstract || Inheritance == InheritanceModifier.Interface;

        public Method() { }
        public Method(string name) => Name = name;
        public Method(Type type, string name) : this(name) => Type = type;        
        public Method(ReadModifier access, Type type, string name) : this(type, name) => Access = access;
        public Method(Type type, string name, params Arg[] args) : this(type, name) => Arguments = args;
        public Method(ReadModifier access, Type type, string name, params Arg[] args) : this(access, type, name) => Arguments = args;

        public override IEnumerable<ISourceNode> Children()
        {
            if (Body != null && Inheritance == InheritanceModifier.Abstract)
                throw new ArgumentException("Abstract methods cannot have bodies");
            foreach (var statement in (Body?.Statements).AsAll())
                yield return statement;
        }

        public override IEnumerable<string> Prefix()
        {
            var signature = new StringBuilder($"{Modifiers}{(Type ?? Type.Void).Text()} {Name}");
            if (GenericParameters.Exist())
                signature.Append("<")
                         .Append(string.Join(",", GenericParameters))
                         .Append(">");
            signature.Append("(")
                     .Append(string.Join(", ", Arguments.AsAll().Select(a => a.Text())))
                     .Append(")");

            if (Params != null)
            {
                if (Arguments.Exist())
                    signature.Append(", ");
                signature.Append(Params.Text());
            }

            if (SignatureOnly)
            {
                signature.Append(";");
                yield return signature.ToString();
            }
            else
            {
                yield return signature.ToString();
                yield return "{";
            }
        }

        public override IEnumerable<string> Suffix()
        {
            if (!SignatureOnly)
                yield return "}";
        }
    }
}

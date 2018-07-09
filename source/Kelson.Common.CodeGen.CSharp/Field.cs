using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Field : Member
    {
        public WriteModifier WriteAccess { get; set; }
        public string Assignment { get; set; }

        public Field(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        public Field(ReadModifier mod, Type type, string name) : this(type, name) => Access = mod;

        public override IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public override IEnumerable<string> Prefix()
        {
            if (string.IsNullOrEmpty(Assignment))
                yield return $"{Access.ToSource()} {Scope.ToSource(pad: true)}{WriteAccess.ToSource(pad: true)}{Name};";
            else
                yield return $"{Access.ToSource()} {Scope.ToSource(pad: true)}{WriteAccess.ToSource(pad: true)}{Name} = {Assignment};";
        }

        public override IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Event : Member
    {
        static readonly string[] __ACTION = new string[] { "Action" };
        static readonly string[] __SYSTEM_ACTION = new string[] { "System", "Action" };

        private Type _type;
        public override Type Type
        {
            get => _type;
            set
            {
                if (!value.FullName.SequenceEqual(__ACTION) && !value.FullName.SequenceEqual(__SYSTEM_ACTION))
                    throw new ArgumentException("Events must have a type of System Action");
                _type = value;
            }
        }

        public Event() { }
        public Event(string name, params Type[] of)
        {
            Name = name;
            Type = new Type("Action", of);
        }

        public override IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public override IEnumerable<string> Prefix()
        {
            yield return $"{Modifiers}event {Type.Text()} {Name};";
        }

        public override IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public abstract class Property : Member
    { 
        private ReadModifier _getterAccess;
        public ReadModifier GetterAccess
        {
            get => _getterAccess == Access ? ReadModifier.None : _getterAccess;
            set => _getterAccess = value;
        }

        private ReadModifier _setterAccess;
        public ReadModifier SetterAccess
        {
            get => _setterAccess == Access ? ReadModifier.None : _setterAccess;
            set => _setterAccess = value;
        }

        protected string Signature
        {
            get
            {
                string mods = Modifiers;
                if (mods.Length > 0)
                    return $"{mods} {Type.Text()} {Name}";
                else
                    return $"{Type.Text()} {Name}";
            }
        }
    }

    public class OverridenProperty : Property
    {
        private Block _getter;
        public Block Getter
        {
            get
            {
                _getter.Line = $"{GetterAccess.ToSource(pad: true)}get";
                return _getter;
            }
            set => _getter = value;
        }

        private Block _setter;
        public Block Setter
        {
            get
            {
                _setter.Line = $"{SetterAccess.ToSource(pad: true)}set";
                return _setter;
            }
            set => _setter = value;            
        }

        [Obsolete("This constructor is for derializers")]
        public OverridenProperty()
        {
            // ya'll better be a deserializer 👀🔪
        }

        public OverridenProperty(Body getter, Body setter)
        {
            Getter = new Block { Statements = getter.Statements };
            Setter = new Block { Statements = setter.Statements };
        }

        public override IEnumerable<ISourceNode> Children()
        {
            yield return Getter;
            yield return Setter;
        }

        public override IEnumerable<string> Prefix()
        {
            yield return Signature;
            yield return "{";
        }

        public override IEnumerable<string> Suffix()
        {
            yield return "}";
        }
    }
}

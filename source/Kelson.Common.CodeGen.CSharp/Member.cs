using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public static class Members
    {
        public static Field[] Fields(params (ReadModifier mod, Type type, string name)[] fields)
            => fields.Select(f => new Field(f.mod, f.type, f.name)).ToArray();
        public static Event[] Events(params (string name, Type action)[] events) => events.Select(e => new Event(e.name, e.action.GenericParameters)).ToArray();
        public static Property[] AutoProperties(params (Type type, string name)[] properties) => properties.Select(p => new AutoProperty(p.type, p.name)).ToArray();
        public static Method[] Methods(params (Type type, string name)[] methods) => methods.Select(m => new Method(m.type, m.name)).ToArray();
        public static Method[] Methods(params Method[] methods) => methods;
    }

    public abstract class Member : ISourceNode
    {
        public virtual ReadModifier Access { get; set; }
        public virtual ScopeModifier Scope { get; set; }
        public virtual InheritanceModifier Inheritance { get; set; }
        public virtual Type Type { get; set; }
        public virtual string Name { get; set; }

        protected string Modifiers
        {
            get
            {
                string modifiers = string.Join(" ", new string[] { Access.ToSource(), Scope.ToSource(), Inheritance.ToSource(), }.Where(s => !string.IsNullOrEmpty(s)));
                if (string.IsNullOrEmpty(modifiers))
                    return "";
                else
                    return modifiers + " ";
            }
        }            

        public abstract IEnumerable<string> Prefix();
        public abstract IEnumerable<string> Suffix();
        public abstract IEnumerable<ISourceNode> Children();
    }
}

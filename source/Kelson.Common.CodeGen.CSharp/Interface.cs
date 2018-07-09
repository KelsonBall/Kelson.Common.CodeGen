using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Interface : TypeDef
    {
        public Event[] Events { get; set; }
        public Property[] Properties { get; set; }
        public Method[] Methods { get; set; }

        public Interface() { }

        public Interface(string name) => Name = name;

        public override IEnumerable<string> Prefix()
        {
            StringBuilder header = 
                new StringBuilder($"{Access.ToSource(pad: true)}interface ")        
                    .Append(Name);
            if (GenericParameters.Exist())
                header.Append("<")
                          .Append(string.Join(",", GenericParameters))
                          .Append(">");
            if (BaseInterfaces.Exist())
                header.Append(" : ")
                      .Append(string.Join(", ", BaseInterfaces.AsAll().Select(b => b.Text())));
            yield return header.ToString();
            yield return "{";
        }

        public override IEnumerable<ISourceNode> Children()
        {
            foreach (var @event in Events.AsAll())
            {
                @event.Access = ReadModifier.None;
                @event.Scope = ScopeModifier.None;
                @event.Inheritance = InheritanceModifier.None;
                yield return @event;
            }

            foreach (var property in Properties.AsAll())
            {
                property.Access = ReadModifier.None;
                property.GetterAccess = ReadModifier.None;
                property.SetterAccess = ReadModifier.None;
                property.Scope = ScopeModifier.None;
                property.Inheritance = InheritanceModifier.None;
                yield return property;
            }

            foreach (var method in Methods.AsAll())
            {
                method.Access = ReadModifier.None;
                method.Scope = ScopeModifier.None;
                method.Inheritance = InheritanceModifier.Interface;
                yield return method;
            }
        }
        
        public override IEnumerable<string> Suffix()
        {
            yield return "}";
        }
    }
}

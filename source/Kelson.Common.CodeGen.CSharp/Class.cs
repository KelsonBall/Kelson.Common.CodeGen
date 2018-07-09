using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Class : TypeDef
    {        
        public BaseClass[] BaseClasses { get; set; }
                
        public Event[] Events { get; set; }
        public Field[] Fields { get; set; }
        public Property[] Properties { get; set; }
        public Constructor[] Constructors { get; set; }
        public Method[] Methods { get; set; }
        
        public Class() { }

        public Class(string name) => Name = name;

        public override IEnumerable<string> Prefix()
        {
            StringBuilder header = new StringBuilder();
            header.Append(Access.ToSource());
            header.Append(" class ").Append(Name);
            if (GenericParameters.Exist())
                header.Append("<")
                          .Append(string.Join(",", GenericParameters))
                          .Append(">");
            if (BaseClasses.Exist() || BaseInterfaces.Exist())            
                header.Append(" : ")
                      .Append(string.Join(", ", BaseClasses.SelectText()
                         .Concat(BaseInterfaces.SelectText())));
            yield return header.ToString();
            yield return "{";
        }

        public override IEnumerable<ISourceNode> Children()
        {
            foreach (var @event in Events.AsAll())
                yield return @event;
            foreach (var field in Fields.AsAll())
                yield return field;
            foreach (var prop in Properties.AsAll())
                yield return prop;
            foreach (var ctor in Constructors.AsAll())
                yield return ctor;
            foreach (var method in Methods.AsAll())
                yield return method;
        }

        public override IEnumerable<string> Suffix()
        {
            yield return "}";
        }
    }
}

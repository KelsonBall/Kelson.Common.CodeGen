using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public class Namespace : ISourceNode
    {
        public string[] FullName { get; set; }
        public Header Header { get; set; }
        public Interface[] Interfaces { get; set; }
        public Class[] Classes { get; set; }

        public Namespace()
        {

        }
        
        public Namespace(string name, params TypeDef[] types)
        {
            FullName = name.Split('.');
            Interfaces = types.Where(t => t is Interface).Select(t => (Interface)t).ToArray();
            Classes = types.Where(t => t is Class).Select(t => (Class)t).ToArray();
        }

        public IEnumerable<string> Prefix()
        {
            yield return $"namespace {string.Join(".", FullName)}";
            yield return "{";
        }

        public IEnumerable<ISourceNode> Children()
        {
            if (Header != null)           
                yield return Header;                            
            foreach (var @interface in Interfaces.AsAll())
                yield return @interface;
            foreach (var @class in Classes.AsAll())
                yield return @class;
        }        

        public IEnumerable<string> Suffix()
        {
            yield return "}";
        }
    }
}

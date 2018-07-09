using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Kelson.Common.CodeGen.CSharp
{
    public static class TypeRefs
    {
        public static Type[] Of(params string[] types) => types.Select(t => new Type(t)).ToArray();
    }

    public class Type : ISourceNode, IEnumerable<string>
    {
        public static Type String => new Type("string");
        public static Type Int32 => new Type("int");
        public static Type Double => new Type("double");
        public static Type Object => new Type("object");
        public static Type Dynamic => new Type("dynamic");
        public static Type Void => new Type("void");
        public static Type T  => new Type("T");
        public static Type T2 => new Type("T2");
        public static Type T3 => new Type("T3");

        public static Type Of(string type, params Type[] generics) => new Type(type, generics);
        public static Type ActionOf(params Type[] generics) => new Type("Action", generics);

        public string[] FullName { get; set; }
        public Type[] GenericParameters { get; set; }

        public Type() { }

        public Type(string name, params Type[] generics)
        {
            FullName = name.Split('.');
            GenericParameters = generics;
        }

        public IEnumerable<string> Prefix()
        {
            if (GenericParameters.Exist())
                yield return $"{string.Join(".", FullName)}<{string.Join(",", GenericParameters.AsAll().SelectMany(p => p.Prefix()))}>";
            else
                yield return $"{string.Join(".", FullName)}";
        }

        public IEnumerable<ISourceNode> Children()
        {
            yield break;
        }        

        public IEnumerable<string> Suffix()
        {
            yield break;
        }

        public void Add(params string[] names) => FullName = (FullName ?? new string[0]).Concat(names).ToArray();

        public IEnumerator<string> GetEnumerator() => FullName.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

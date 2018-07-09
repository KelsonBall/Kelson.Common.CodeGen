using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public abstract class BaseType : ISourceNode
    {
        public string Name { get; set; }
        public Type[] GenericParameters { get; set; }

        public IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public IEnumerable<string> Prefix()
        {
            if (GenericParameters.Exist())
                yield return $"{Name}<{string.Join(",", GenericParameters.AsAll().SelectMany(p => p.Prefix()))}>";
            else
                yield return $"{Name}";
        }

        public IEnumerable<string> Suffix()
        {
            yield break;
        }
    }

    public static class Inherits
    {
        public static BaseClass[] Classes(params string[] names) => names.Select(n => new BaseClass(n)).ToArray();
        public static BaseClass[] Classes(params BaseClass[] values) => values;
        public static BaseInterface[] Interfaces(params string[] names) => names.Select(n => new BaseInterface(n)).ToArray();
        public static BaseInterface[] Interfaces(params BaseInterface[] values) => values;
    }

    public class BaseClass : BaseType
    {
        public BaseClass() { }
        public BaseClass(string name) => Name = name;
        public BaseClass(string name, params Type[] generics) : this(name) => GenericParameters = generics;
    }

    public class BaseInterface : BaseType
    {
        public BaseInterface() { }
        public BaseInterface(string name) => Name = name;
        public BaseInterface(string name, params Type[] generics) : this(name) => GenericParameters = generics;
    }
}

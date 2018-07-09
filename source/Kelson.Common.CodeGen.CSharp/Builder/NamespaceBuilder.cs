using System;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp.Builder
{
    public class NamespaceBuilder : Builder<Namespace>
    {
        public NamespaceBuilder WithHeader(Action<HeaderBuilder> action)
        {
            value.Header = One<HeaderBuilder, Header>(action);
            return this;
        }

        public NamespaceBuilder WithInterfaces(params Action<InterfaceBuilder>[] actions)
        {
            value.Interfaces = (value.Interfaces ?? new Interface[0])
                                    .Concat(Many<InterfaceBuilder, Interface>(actions))
                                    .ToArray();
            return this;
        }

        public NamespaceBuilder WithClasses(params Action<ClassBuilder>[] actions)
        {
            value.Classes = (value.Classes ?? new Class[0])
                                    .Concat(Many<ClassBuilder, Class>(actions))
                                    .ToArray();
            return this;
        }
    }
}

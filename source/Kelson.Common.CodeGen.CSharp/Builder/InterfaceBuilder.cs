using System;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp.Builder
{
    public class InterfaceBuilder : Builder<Interface>
    {
        public CompleteInterfaceBuilder WithName(string name, params string[] generics)
        {
            value.Name = name;
            value.GenericParameters = generics;
            return new CompleteInterfaceBuilder(this);
        }

        public class CompleteInterfaceBuilder : Builder<Interface>
        {
            public CompleteInterfaceBuilder(InterfaceBuilder parent) : base(parent) { }

            public CompleteInterfaceBuilder WithEvents(params Action<EventBuilder>[] actions)
            {
                value.Events = value.Events.AsAll()
                                    .Concat(Many<EventBuilder, Event>(actions)
                                                .ForEach(e => e.Access = ReadModifier.None))
                                    .ToArray();
                return this;
            }

            public CompleteInterfaceBuilder WithProperties(params Action<PropertyBuilder>[] actions)
            {
                value.Properties = value.Properties.AsAll()
                                    .Concat(Many<PropertyBuilder, Property>(actions)
                                                .ForEach(e => e.Access = ReadModifier.None))
                                    .ToArray();
                return this;
            }

            public CompleteInterfaceBuilder WithMethods(params Action<MethodBuilder>[] actions)
            {
                value.Methods = value.Methods.AsAll()
                                    .Concat(Many<MethodBuilder, Method>(actions)
                                                .ForEach(e => e.Access = ReadModifier.None))
                                    .ToArray();
                return this;
            }
        }
    }    
}

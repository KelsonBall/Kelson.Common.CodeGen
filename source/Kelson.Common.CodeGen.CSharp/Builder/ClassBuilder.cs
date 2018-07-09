using System;

namespace Kelson.Common.CodeGen.CSharp.Builder
{
    public class ClassBuilder : Builder<Class>
    {
        public ClassBuilder() : base()
        {
            value.Access = ReadModifier.Public;
        }

        public CompleteClassBuilder WithName(string name, params string[] generics)
        {
            value.Name = name;
            value.GenericParameters = generics;
            return new CompleteClassBuilder(this);
        }

        public class CompleteClassBuilder : Builder<Class>
        {
            internal CompleteClassBuilder(ClassBuilder parent) : base(parent) { }

            public CompleteClassBuilder WithAccess(ReadModifier modifier)
            {
                value.Access = modifier;
                return this;
            }

            public CompleteClassBuilder WithTypeConstraint(string constraint)
            {
                return this;
            }

            public CompleteClassBuilder WithEvents(params Action<EventBuilder>[] actions)
            {
                return this;
            }

            public CompleteClassBuilder WithFields(params Action<FieldBuilder>[] actions)
            {
                return this;
            }

            public CompleteClassBuilder WithProperties(params Action<PropertyBuilder>[] actions)
            {
                return this;
            }

            public CompleteClassBuilder WithMethods(params Action<MethodBuilder>[] actions)
            {
                return this;
            }

            public CompleteClassBuilder WithConstructors(params Action<ConstructorBuilder>[] actions)
            {
                return this;
            }

            public CompleteClassBuilder WithClasses(params Action<ClassBuilder>[] actions)
            {
                return this;
            }
        }
    }
}

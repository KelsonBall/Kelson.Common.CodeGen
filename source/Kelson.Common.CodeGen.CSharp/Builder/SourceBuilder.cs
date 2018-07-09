using System;

namespace Kelson.Common.CodeGen.CSharp.Builder
{
    public class SourceBuilder : Builder<CodeFile>
    {
        public SourceBuilder() : base() { }
        public SourceBuilder(SourceBuilder parent, Func<CodeFile, CodeFile> transform) : base(parent, transform) { }

        public SourceBuilder WithHeader(Action<HeaderBuilder> action)
        {
            return new SourceBuilder(this, value =>
            {
                value.Header = One<HeaderBuilder, Header>(action);
                return value;
            });            
        }

        public SourceBuilder WithNamespace(Action<NamespaceBuilder> action)
        {
            return new SourceBuilder(this, value =>
            {
                value.Namespace = One<NamespaceBuilder, Namespace>(action);
                return value;
            });
        }
    }    

    public class ConstructorBuilder : Builder<Constructor>
    {
        public ConstructorBuilder() : base() { }
        public ConstructorBuilder(ConstructorBuilder parent, Func<Constructor, Constructor> transform) : base(parent, transform) { }

        public ConstructorBuilder WithAccess(ReadModifier modifier)
        {
            return new ConstructorBuilder(this, value =>
            {
                value.Access = modifier;
                return value;
            });
        }
    }

    public abstract class MemberBuilder<TSelf, TMember> : Builder<TMember> where TMember : Member where TSelf : MemberBuilder<TSelf, TMember>
    {
        public TSelf WithAccess(ReadModifier modifier)
        {
            value.Access = modifier;
            return (TSelf)this;
        }

        public TSelf WithScope(ScopeModifier modifier)
        {
            value.Scope = modifier;
            return (TSelf)this;
        }

        public TSelf WithInheritance(InheritanceModifier modifier)
        {
            value.Inheritance = modifier;
            return (TSelf)this;
        }

        public TSelf WithType(Type type)
        {
            value.Type = type;
            return (TSelf)this;
        }

        public TSelf WithName(string name)
        {
            value.Name = name;
            return (TSelf)this;
        }
    }

    public class MethodBuilder : MemberBuilder<MethodBuilder, Method>
    {
    }

    public class PropertyBuilder : MemberBuilder<PropertyBuilder, Property>
    {
    }

    public class FieldBuilder : MemberBuilder<FieldBuilder, Field>
    {
    }

    public class EventBuilder : MemberBuilder<EventBuilder, Event>
    {
    }
}

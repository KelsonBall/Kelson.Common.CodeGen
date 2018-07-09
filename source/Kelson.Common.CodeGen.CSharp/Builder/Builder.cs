using System;
using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp.Builder
{
   
    public abstract class PreBuilder<T> : IComposableBuilder<T>
    {
        public IComposableBuilder<T> Parent { get; }
        public Func<T, T> Transform { get; }

        protected PreBuilder()
        {
            Parent = null;
            Transform = _ => Activator.CreateInstance<T>();
        }

        protected PreBuilder(IComposableBuilder<T> parent, Func<T, T> transform)
        {
            Parent = parent;
            Transform = transform;
        }
    }


    public abstract class Builder<T> : IFinalBuilder<T>
    {
        public IComposableBuilder<T> Parent { get; }
        public Func<T, T> Transform { get; }

        public Builder()
        {
            Parent = null;
            Transform = _ => Activator.CreateInstance<T>();
        }

        protected Builder(Builder<T> parent, Func<T, T> transform)
        {
            this.Parent = parent;
            this.Transform = transform;
        }

        public virtual T Build()
        {
            if (Parent != null)
                return Transform(Parent.Build());
            else
                return Transform(default);
        }

        protected TBuild One<TBuilder, TBuild>(Action<TBuilder> action) where TBuilder : IFinalBuilder<TBuild>
        {
            var builder = Activator.CreateInstance<TBuilder>();
            action(builder);
            return builder.Build();
        }

        protected IEnumerable<TBuild> Many<TBuilder, TBuild>(params Action<TBuilder>[] actions) where TBuilder : IFinalBuilder<TBuild>
        {
            foreach (var action in actions)
                yield return One<TBuilder, TBuild>(action);
        }
    }    
}

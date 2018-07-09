using System;

namespace Kelson.Common.CodeGen.CSharp.Builder
{
    public interface IComposableBuilder<T>
    {
        IComposableBuilder<T> Parent { get; }
        Func<T, T> Transform { get; }
    }

    public interface IFinalBuilder<T> : IComposableBuilder<T>
    {
        T Build();
    }
}

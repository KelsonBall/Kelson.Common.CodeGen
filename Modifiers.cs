using System;

namespace Kelson.CommonCodeGen
{
    public enum ReadModifier
    {
        Private,
        Protected,
        [Obsolete("Requires C# 7.2 code target or newer")]
        Private_Protected,
        Internal,
        Public,
    }

    public enum WriteModifier
    {
        Write,
        Const,
        Readonly,
    }

    public enum ScopeModifier
    {
        Instance,
        Static
    }

    public enum RefModifier
    {
        None,
        In,
        Out,
        Ref,
    }
}

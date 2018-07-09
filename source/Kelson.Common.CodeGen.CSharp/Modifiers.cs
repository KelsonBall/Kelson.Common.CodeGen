using System;

namespace Kelson.Common.CodeGen.CSharp
{
    public enum ReadModifier
    {
        None,
        Private,
        Protected,
        [Obsolete("Requires C# 7.2 code target or newer")]
        Private_Protected,
        Internal,
        Public,
    }

    public enum WriteModifier
    {
        None,
        Const,
        Readonly,
    }

    public enum ScopeModifier
    {
        None,
        Static
    }

    public enum InheritanceModifier
    {
        None,
        Interface,
        Abstract,
        Virtual,
        Override,
        New,
    }

    public enum RefModifier
    {
        None,
        [Obsolete("Requires C# 7.2 code target or newer")]
        In,
        Out,
        Ref,
    }

    public static class ModifierExtensions
    {
        private static string ToCode<T>(this T value) where T : struct
        {
            return value.ToString().ToLower().Replace('_', ' ');
        }

        private static string ToCodeOrEmpty<T>(this T value, T check, bool pad) where T : struct
        {
            return (value as int?) == (check as int?) ? "" : value.ToCode() + (pad ? " " : "");
        }

        public static string ToSource(this ReadModifier modifier, bool pad = false)
            => modifier.ToCodeOrEmpty(ReadModifier.None, pad);

        public static string ToSource(this WriteModifier modifier, bool pad = false)
            => modifier.ToCodeOrEmpty(WriteModifier.None, pad);

        public static string ToSource(this ScopeModifier modifier, bool pad = false)
            => modifier.ToCodeOrEmpty(ScopeModifier.None, pad);

        public static string ToSource(this InheritanceModifier modifier, bool pad = false)
            => modifier.ToCodeOrEmpty(InheritanceModifier.None, pad);

        public static string ToSource(this RefModifier modifier, bool pad = false)
            => modifier.ToCodeOrEmpty(RefModifier.None, pad);
    }
}

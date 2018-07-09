namespace Kelson.Common.CodeGen.CSharp.Builder
{
    public class HeaderBuilder : Builder<Header>
    {
        public HeaderBuilder WithImports(params string[] imports)
        {
            value.Imports = Imports.Of(imports);
            return this;
        }

        public HeaderBuilder WithStaticImports(params Type[] imports)
        {
            value.StaticImports = Imports.Statics(imports);
            return this;
        }

        public HeaderBuilder WithAliases(params (string alias, Type type)[] aliases)
        {
            value.Aliases = Imports.AliasesOf(aliases);
            return this;
        }
    }
}

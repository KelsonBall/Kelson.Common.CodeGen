namespace Kelson.CommonCodeGen
{
    public abstract class ConstructorPrecall : ISourceNode
    {
        public string[] Arguments { get; set; }

        public abstract string ToSource();
    }
}

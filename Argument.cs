namespace Kelson.CommonCodeGen
{
    public abstract class Argument : ISourceNode
    {
        public TypeReference Type { get; set; }
        public string Name { get; set; }

        public abstract string ToSource();
    }
}

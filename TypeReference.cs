namespace Kelson.CommonCodeGen
{
    public class TypeReference : ISourceNode
    {
        public string[] FullName { get; set; }
        public TypeReference[] GenericParameters { get; set; }
    }
}

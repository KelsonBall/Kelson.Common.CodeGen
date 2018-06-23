namespace Kelson.CommonCodeGen
{
    public abstract class Member : ISourceNode
    {                
        public ReadModifier Access { get; set; }        
        public ScopeModifier Scope { get; set; }
        public string Name { get; set; }

        public abstract string ToSource();        
    }
}

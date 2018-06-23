namespace Kelson.CommonCodeGen
{
    public class Property : Member
    {
        public class GetterSetter : ISourceNode
        {
            public ReadModifier Access { get; set; }
            public string[] Body { get; set; }

            public string ToSource()
            {
                throw new System.NotImplementedException();
            }
        }        

        public GetterSetter Getter { get; set; }
        public GetterSetter Setter { get; set; }

        public override string ToSource()
        {
            throw new System.NotImplementedException();
        }
    }
}

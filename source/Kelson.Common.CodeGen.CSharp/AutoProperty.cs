using System.Collections.Generic;

namespace Kelson.Common.CodeGen.CSharp
{
    public class AutoProperty : Property
    {
        public string Assignment { get; set; }        

        public AutoProperty() { }
        public AutoProperty(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        public override IEnumerable<ISourceNode> Children()
        {
            yield break;
        }

        public override IEnumerable<string> Prefix()
        {
            if (string.IsNullOrEmpty(Assignment))
                yield return $"{Signature} {{ get; set; }}";
            else
                yield return $"{Signature} {{ get; set; }} = {Assignment};";
        }

        public override IEnumerable<string> Suffix()
        {
            yield break;
        }
    }
}

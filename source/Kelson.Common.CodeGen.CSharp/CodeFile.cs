using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen.CSharp
{
    public class CodeFile : ISourceNode
    {
        public const string GENERATED_CODE_WARNING = @"// START GENERATED CODE";
        public const string END_CODE_WARNING = @"// END GENERATED CODE";

        public Header Header { get; set; }
        public Namespace Namespace { get; set; }
        
        public IEnumerable<string> Prefix()
        {
            yield return GENERATED_CODE_WARNING;
            if (Header != null)
                foreach (var line in Header.Prefix())
                    yield return line;
            if (Namespace != null)
                foreach (var line in Namespace.Prefix())
                    yield return line;
        }

        public IEnumerable<ISourceNode> Children()
        {
            if (Namespace != null)
                return Namespace.Children();
            else
                return Enumerable.Empty<ISourceNode>();
        }

        public IEnumerable<string> Suffix()
        {
            if (Namespace != null)
                foreach (var line in Namespace.Suffix())
                    yield return line;
            yield return END_CODE_WARNING;
        }
    }
}

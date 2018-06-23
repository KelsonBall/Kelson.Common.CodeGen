using System;

namespace Kelson.CommonCodeGen
{
    public class Constructor : ISourceNode
    {
        public ConstructorPrecall Precall { get; set; }
        public Body CtorBody { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

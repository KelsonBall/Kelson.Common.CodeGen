using System;

namespace Kelson.CommonCodeGen
{
    public class Class : ISourceNode
    {        
        public ReadModifier Access { get; set; }
        public string Name { get; set; }
        public TypeReference[] GenericParameters { get; set; }
        public BaseClass[] BaseClasses { get; set; }
        public BaseInterface[] BaseInterfaces { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

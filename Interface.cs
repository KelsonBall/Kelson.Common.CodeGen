using System;

namespace Kelson.CommonCodeGen
{
    public class Interface : ISourceNode
    {        
        public ReadModifier Access { get; set; }
        public string Name { get; set; }
        public string[] GenericParameters { get; set; }
        public BaseInterface[] BaseInterfaces { get; set; }
        public Property[] Properties { get; set; }
        public Method[] Methods { get; set; }

        public string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

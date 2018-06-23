using System;

namespace Kelson.CommonCodeGen
{
    public class Method : Member
    {
        public string[] GenericParameters { get; set; }

        public override string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

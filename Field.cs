using System;

namespace Kelson.CommonCodeGen
{
    public class Field : Member
    {
        public WriteModifier WriteAccess { get; set; }
        public string Assignment { get; set; }

        public override string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

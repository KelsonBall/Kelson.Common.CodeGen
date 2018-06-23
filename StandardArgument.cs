using System;

namespace Kelson.CommonCodeGen
{
    public class StandardArgument : Argument
    {
        public RefModifier RefType { get; set; }

        public override string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

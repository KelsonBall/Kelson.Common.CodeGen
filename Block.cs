using System;

namespace Kelson.CommonCodeGen
{
    public class Block : Statement
    {
        public Statement[] InnerStatements { get; set; }

        public override string ToSource()
        {
            throw new NotImplementedException();
        }
    }
}

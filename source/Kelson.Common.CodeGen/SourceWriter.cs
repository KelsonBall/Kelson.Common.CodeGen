using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Kelson.Common.CodeGen
{
    public class SourceWriter
    {
        const string indent = "    ";

        private readonly ISourceNode root;

        public SourceWriter(ISourceNode node)
        {
            root = node;
        }

        private readonly Stack<string> styleStack = new Stack<string>();

        private void WriteNode(ISourceNode node, TextWriter writer)
        {
            bool isFlat = node.GetType().GetCustomAttribute<FlatAttribute>() != null;

            foreach (var line in node.Prefix())
            {
                writer.Write(styleStack.Peek());
                writer.WriteLine(line);
            }
            
            if (!isFlat)
                styleStack.Push(styleStack.Peek() + indent);

            foreach (var child in node.Children())
                WriteNode(child, writer);

            if (!isFlat)
                styleStack.Pop();

            foreach (var line in node.Suffix())
            {
                writer.Write(styleStack.Peek());
                writer.WriteLine(line);
            }
        }

        public void WriteTo(TextWriter writer)
        {
            styleStack.Push("");
            WriteNode(root, writer);
        }

        public void WriteTo(StringBuilder builder)
        {
            WriteTo(new StringWriter(builder));
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            WriteTo(builder);
            return builder.ToString().Trim();
        }
    }
}

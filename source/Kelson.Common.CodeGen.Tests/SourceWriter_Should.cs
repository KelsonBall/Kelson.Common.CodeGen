using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Kelson.Common.CodeGen.Tests
{
    public class SourceWriter_Should
    {
        class XmlNode : ISourceNode, IEnumerable<ISourceNode>
        {
            private readonly List<ISourceNode> _nodes = new List<ISourceNode>();

            private readonly string Name;

            public XmlNode(string name)
            {
                Name = name;
            }

            public void Add(ISourceNode node) => _nodes.Add(node);

            public IEnumerable<ISourceNode> Children()
            {
                foreach (var node in _nodes)
                    yield return node;
            }

            public IEnumerator<ISourceNode> GetEnumerator() => Children().GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerable<string> Prefix()
            {
                yield return $"<{Name}>";
            }

            public IEnumerable<string> Suffix()
            {
                yield return $"</{Name}>";
            }            
        }

        [Fact]
        public void WriteStructuredData()
        {
            var c = new XmlNode("C");
            var e = new XmlNode("E");
            var d = new XmlNode("D") { e };
            var b = new XmlNode("B") { c, d };                       
            var f = new XmlNode("F");
            var a = new XmlNode("A") { b, f };

            var textA = new SourceWriter(a).ToString();

            var node = new XmlNode("A")
            {
                new XmlNode("B")
                {
                    new XmlNode("C"),
                    new XmlNode("D")
                    {
                        new XmlNode("E"),
                    },
                },
                new XmlNode("F"),
            };

            var nodeText = new SourceWriter(node).ToString();

            var expected = 
@"<A>
    <B>
        <C>
        </C>
        <D>
            <E>
            </E>
        </D>
    </B>
    <F>
    </F>
</A>";
            
            textA.Should().Be(nodeText);
            textA.Should().Be(expected);

            string WithoutSpaces(string source) => source.Replace(" ", "");
            WithoutSpaces(textA).Should().Contain(WithoutSpaces(new SourceWriter(b).ToString()));
        }
    }
}

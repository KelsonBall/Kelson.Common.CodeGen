using System.Linq;
using Xunit;
using FluentAssertions;

namespace Kelson.Common.CodeGen.CSharp.Tests
{
    public class CodeFile_Should
    {
        [Fact]
        public void GenerateCommentWithGenerationWarning_WhenNoMembers()
        {
            var file = new CodeFile { };

            file.Prefix().Single().Should().Be(CodeFile.GENERATED_CODE_WARNING);
            file.Suffix().Single().Should().Be(CodeFile.END_CODE_WARNING);
        }

        [Fact]
        public void GenerateImportList_WhenHasImports()
        {
            var imports = new Import[]
            {
                new Import { FullName = new string[]{ "System" } },
                new Import { FullName = new string[] { "System", "Collections", "Generic" } },
            };

            var file = new CodeFile
            {
                Header = new Header
                {
                    Imports = imports,
                },
            };

            var expectedLines = new string[]
            {
                CodeFile.GENERATED_CODE_WARNING,
                "using System;",
                "using System.Collections.Generic;"
            };

            file.Prefix().Should().ContainInOrder(expectedLines).And.HaveSameCount(expectedLines);
            file.Children().Should().BeEmpty();            
        }

        [Fact]
        public void GenerateNamespace_WhenHasNamespace()
        {
            var classItem = new Class
            {
                Name = "ShouldExist",
            };

            var file = new CodeFile
            {
                Namespace = new Namespace
                {
                    FullName = new string[] { "Test", "Name" },     
                    Classes = new Class[] { classItem },
                }
            };

            var expectedLines = new string[]
            {
                CodeFile.GENERATED_CODE_WARNING,
                "namespace Test.Name",
                "{"
            };

            file.Prefix().Should().ContainInOrder(expectedLines).And.HaveSameCount(expectedLines);
            file.Children().Single().Should().BeSameAs(classItem);
            file.Suffix().First().Should().Be("}");
            file.Suffix().Last().Should().Be(CodeFile.END_CODE_WARNING);
        }
    }
}

using System.Linq;
using Xunit;

namespace Kelson.Common.CodeGen.CSharp.Tests
{
    public class ExampleCaseShould
    {
        [Fact]
        public void GenerateCorrectText()
        {
            var file = new CodeFile
            {
                Header = new Header
                {
                    Imports = Imports.Of("System", "System.Linq", "System.Collections.Generic"),
                    StaticImports = Imports.Statics(Type.Of("System.Console")),
                    Aliases = Imports.AliasesOf(("E", Type.Of("System.Linq.Enumerable")))
                },
                Namespace = new Namespace("Test.Space")
                {
                    Interfaces = new Interface[]
                    {
                        new Interface("IExample")
                        {
                            Access = ReadModifier.Public,
                            GenericParameters = Array.Of( "T" ),
                            BaseInterfaces = Inherits.Interfaces(
                                new BaseInterface("IEnumerable", Type.Of("T")),
                                new BaseInterface("IDisposable")),
                            Events = Members.Events(
                                ("OnAdded", Type.ActionOf(Type.Of("T"))),
                                ("OnCleared", Type.ActionOf()) ),
                            Methods = Members.Methods(
                                new Method(Type.Void, "Clear"),
                                new Method(Type.Void, "Add", new Arg(Type.Of("T"), "item"))),
                            Properties = Members.AutoProperties(
                                (Type.Int32, "Count"),
                                (Type.String, "Name"))
                        }
                    },
                    Classes = 
                    Array.Of(                    
                        new Class("Example")
                        {
                            Access = ReadModifier.Public,
                            GenericParameters = new string[] { "T" },
                            BaseClasses = Inherits.Classes(new BaseClass("System.IO.TextWriter")),
                            BaseInterfaces = Inherits.Interfaces(new BaseInterface("IExample")),
                            Fields = Members.Fields((ReadModifier.Private, Type.String, "_text")),
                            Constructors = new Constructor[]
                            {
                                new Constructor
                                {
                                    Access = ReadModifier.Public,
                                    Arguments = Args.Of((Type.String, "text")),
                                    Body = new Body { Statements = new Statement[] { new Statement("_text = text;") } }
                                }
                            },
                            Events = Members.Events(
                                ("OnAdded", Type.ActionOf(Type.Of("T"))),
                                ("OnCleared", Type.ActionOf())),
                            Methods = Members.Methods(
                                new Method(Type.Void, "Clear"),
                                new Method(Type.Void, "Add", new Arg(Type.Of("T"), "item"))),
                            Properties = Members.AutoProperties(
                                (Type.Int32, "Count"),
                                (Type.String, "Name"))
                        }
                    ),

                    }
                }
            };

            var text = new SourceWriter(file).ToString();

        }
    }
}

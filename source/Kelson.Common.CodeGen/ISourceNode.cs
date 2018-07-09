using System.Collections.Generic;

namespace Kelson.Common.CodeGen
{
    /// <summary>
    /// Defines a hierarchal node in a source file    
    /// </summary>
    public interface ISourceNode
    {
        /// <summary>
        /// Lines to be written before child nodes
        /// </summary>        
        IEnumerable<string> Prefix();

        /// <summary>
        /// Child nodes to be pushed to the SourceWriter's stack and written after the Prefix lines and before the Suffix lines
        /// </summary>        
        IEnumerable<ISourceNode> Children();

        /// <summary>
        /// Lines to be written after child nodes
        /// </summary>        
        IEnumerable<string> Suffix();               
    }
}

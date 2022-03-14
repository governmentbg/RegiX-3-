using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TechnoLogica.Common
{
    /// <summary>
    /// UTF8 String writer
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="builder">String builder</param>
        public Utf8StringWriter(StringBuilder builder) : base(builder) { }
        
        /// <summary>
        /// Set encoding to UTF8
        /// </summary>
        public override Encoding Encoding
        {
            get => Encoding.UTF8;
        }
    }
}

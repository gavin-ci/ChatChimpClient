using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Readers.HTML
{
    public static class HtmlParser
    {
        public static string? getScript( string scriptName ) 
            => $"<script> {Globals.fileLoader.getJsFileContent(scriptName)} </script>";
        
    }
}

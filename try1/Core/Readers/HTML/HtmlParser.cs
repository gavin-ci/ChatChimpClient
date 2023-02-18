using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Readers.HTML
{
    public static class HtmlParser
    {
        public static string constructDocument( string htmlDoc, string[] cssSheets = null, string[] jsScripts = null )
        {
            string DOM = "<style>";
            if(cssSheets.Length > 0 )
                foreach (string sheet in cssSheets) { DOM += sheet; }
            DOM += "</style>";
            if(jsScripts.Length > 0)
                foreach (string script in jsScripts) { DOM += script; }
            DOM += htmlDoc;
            return DOM;
        }
    }
}

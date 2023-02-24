using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Gui.Browser.BrowserEvents {
    public struct JsonStruct {
        public int id { get; set; }
        public List<string?> data { get; set; }

        public JsonStruct( string json ) {

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            reader.Read(); // reads id name
            reader.Read();
            int id = reader.ReadAsInt32() ?? 9999;
            reader.Read(); // reads data name
            data = new List<string>();
            while (reader.Read()) {
                if (reader.Value == null)
                    continue;
                data.Add(reader.Value as string);
            }
        }
    }
}

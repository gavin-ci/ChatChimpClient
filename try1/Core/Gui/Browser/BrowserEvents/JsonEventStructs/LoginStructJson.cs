using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Gui.Browser.BrowserEvents.JsonEventStructs {
    public struct LoginStructJson {
        public string username { get; set; }
        public string password { get; set; }

        public LoginStructJson(JsonStruct json) {
            username = json.data[0];
            password = json.data[1];
        }
    }
}

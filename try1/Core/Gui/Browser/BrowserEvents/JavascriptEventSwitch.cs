﻿using ChatChimpClient.Core.Gui.Browser.BrowserEvents.JsonEventStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ChatChimpClient.Core.Gui.Browser.BrowserEvents {
    public static class JavascriptEventSwitch {

        public static async void HandleEvent( JsonStruct json ) {
            switch(json.id) {
                case (int)JavascriptEventType.LOGIN:
                    LoginStructJson loginJson = new LoginStructJson(json);
                    Globals.client.login(loginJson.username, loginJson.password);
                    // login function
                    return;
            }
        }
    }
}

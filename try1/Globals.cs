using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatChimpClient.Core.FileSystem;
using ChatChimpClient.Core.Gui;
using ChatChimpClient.Core.Gui.Browser;
using ChatChimpClient.Core.Gui.Browser.BrowserEvents;
using ChatChimpClient.Core.Networking;
using ChatChimpClient.Core.PacketHandlers;

namespace ChatChimpClient
{
    public static class Globals
    {
        public static Client client { get; set; }
        public static Browser browser { get; set; }
        public static FileLoader fileLoader { get; set; }
        public static PackageHandler packageHandler { get; set; }

        #region Filesystem
        public const string HTMLFOLDERNAME = "HTML";
        public const string JSFOLDERNAME = "JS";
        public const string GETDIRECTORYTAG = "<dir>";
        #endregion
    }
}

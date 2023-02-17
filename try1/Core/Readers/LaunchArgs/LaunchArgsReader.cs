using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.Readers.LaunchArgs {
    public struct argsInfo {
        public string name;
        public string value;
    }

    public class LaunchArgsReader {
        public List<argsInfo> argsList = new List<argsInfo>();
        public LaunchArgsReader( string[] args ) {
            foreach ( string argument in args ) {
                argsInfo argInfo = new argsInfo();
                string[] argSplit = argument.Split('=');
                argInfo.name = argSplit[0];
                argInfo.value = argSplit[1];
                argsList.Add( argInfo );
            }
        }
    }
}

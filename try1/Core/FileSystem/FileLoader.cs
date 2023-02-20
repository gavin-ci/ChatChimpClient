using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChimpClient.Core.FileSystem
{
    public class FileLoader
    {
        string assetsFolderPath { get; set; }
        public FileLoader( string assetsFolderPath ) {
            this.assetsFolderPath = assetsFolderPath;
        }

        public string getHtmlFileContent( string fileName )
            => File.ReadAllText( 
                Path.Combine(
                    assetsFolderPath, 
                    Globals.HTMLFOLDERNAME, 
                    fileName
                ) ).Replace( Globals.GETDIRECTORYTAG, Directory.GetCurrentDirectory() );
    }
}

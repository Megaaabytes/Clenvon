using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clenvon.Parsing;
using System.IO;

namespace Clenvon.IO
{
    public class GetFile
    {
        public static bool CheckFiles(string path)
        {
            if(File.Exists(path) == false)
            {
                Console.WriteLine("\n[FATAL ERROR] The specified file does not exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetFileFromData(string projectDirectory, string data)
        {
            string dataPath = Path.Combine(projectDirectory, data);
            return dataPath;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clenvon.Misc
{
    public class GetCompilerDirectory
    {
        public static string GetDirectory()
        {
            if (File.Exists(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build/vcvars32.bat") == false)
            {
                return "File not found";
            }
            else
            {
                return @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\vcvars32.bat";
            }
        }
    }
}

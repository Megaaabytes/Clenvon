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

        public static Instructions[] GetHeaderFilesFromInclude(Instructions[] instructions)
        {
            bool includePathExists = false;
            Instructions instructionIncludePath = new Instructions();
            List<Instructions> instructionList = new List<Instructions>();

            foreach(Instructions instruction in instructions)
            {
                if(instruction.type == InstructionType.AddIncludeDirectory)
                {
                    includePathExists = true;
                    instructionIncludePath = instruction;
                }
                else
                {
                    continue;
                }
            }

            if(includePathExists == false)
            {
                Console.WriteLine("[WARNING] Include directory command useless as the directory specified does not exist.");
                return instructions;
            }
            else
            {
                foreach(Instructions instruction in instructions)
                {
                    instructionList.Add(instruction);
                }
                string path = GetFileFromData(InstructionChecker.ProjectInstruction.data, instructionIncludePath.data);
                instructionList.Remove(instructionIncludePath);
                List<Instructions> headerFiles = new List<Instructions>(); 
                foreach(string file in Directory.GetFiles(path))
                {
                    headerFiles.Add(new Instructions(InstructionType.AddHeader, file)); 
                }
                foreach(Instructions instruction in headerFiles)
                {
                    instructionList.Add(instruction);
                }
            }
            return instructionList.ToArray();
        }

        public static string GetFileFromData(string projectDirectory, string data)
        {
            string dataPath = Path.Combine(projectDirectory, data);
            return dataPath;
        }
    }
}

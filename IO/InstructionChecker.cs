using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clenvon.IO
{
    public class InstructionChecker
    {
        public static Instructions ProjectInstruction { get; private set; }

        public static bool CheckInstructionsForErrors(Instructions[] instructions)
        {
            Instructions projectInstruction = new Instructions();
            bool gotProjectInstruction = false;
            bool gotCompileBlock = false;

            foreach(Instructions instruction in instructions)
            {
                if(instruction.type == InstructionType.Compile)
                {
                    gotCompileBlock = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if(gotCompileBlock == false)
            {
                Console.WriteLine("[FATAL ERROR] No compile block was detected.");
                return false;
            }
            foreach (Instructions instruction in instructions)
            {
                if (instruction.type == InstructionType.Project)
                {
                    gotProjectInstruction = true;
                    projectInstruction = instruction;
                    ProjectInstruction = instruction;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (gotProjectInstruction == false)
            {
                Console.WriteLine("[FATAL ERROR] No project directory instruction was detected.");
                return false;
            }

            foreach(Instructions instruction in instructions)
            {
                if(instruction.type == InstructionType.Project)
                {
                    continue;
                }

                if(instruction.type == InstructionType.AddClass)
                {
                    string addClass = GetFile.GetFileFromData(projectInstruction.data, instruction.data);
                    if(File.Exists(addClass) == false)
                    {
                        Console.WriteLine($"[FATAL ERROR] {addClass} does not exist.");
                        return false;
                    }
                }
                else if(instruction.type == InstructionType.AddHeader)
                {
                    string addHeader = GetFile.GetFileFromData(projectInstruction.data, instruction.data);
                    if (File.Exists(addHeader) == false)
                    {
                        Console.WriteLine($"[FATAL ERROR] {addHeader} does not exist.");
                        return false;
                    }
                }
                else if(instruction.type == InstructionType.AddIncludeDirectory)
                {
                    string path = GetFile.GetFileFromData(projectInstruction.data, instruction.data);
                    if(Directory.Exists(path) == false)
                    {
                        Console.WriteLine($"[FATAL ERROR] Include {path} does not exist.");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

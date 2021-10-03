using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clenvon.IO;

namespace Clenvon.Instruction
{
    public class InstructionTools
    {
        public static ReadableInstructions[] CreateReadableInstructions(Instructions[] instructions)
        {
            List<ReadableInstructions> fullInstruction = new List<ReadableInstructions>();
            int index = 0;
            foreach(Instructions instruction in instructions)
            {
                if(index == 0)
                {
                    index++;
                    continue;
                }
                else
                {
                    if (instruction.type == InstructionType.AddClass)
                    {
                        fullInstruction.Add(new ReadableInstructions(instruction.data, ReadableInstructionType.Source));
                    }
                    else if (instruction.type == InstructionType.AddHeaderDirectory)
                    {
                        fullInstruction.Add(new ReadableInstructions(instruction.data, ReadableInstructionType.Header));
                    }
                }
            }
            return fullInstruction.ToArray();
        }

        public static bool BeginCompiling(ReadableInstructions[] instructions)
        {
            try
            {
                Process compileApplication = new Process();
                compileApplication.StartInfo.FileName = "cmd.exe";
                compileApplication.StartInfo.WorkingDirectory = InstructionChecker.ProjectInstruction.data;
                compileApplication.StartInfo.RedirectStandardInput = true;
                compileApplication.StartInfo.RedirectStandardOutput = true;
                compileApplication.StartInfo.UseShellExecute = false;
                compileApplication.Start();
                compileApplication.StandardInput.WriteLine("\"" + @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\vcvars32.bat" + "\"");
                compileApplication.StandardInput.WriteLine($@"{GenerateCommand(instructions)}");
                compileApplication.StandardInput.WriteLine(@"exit");
                string output = compileApplication.StandardOutput.ReadToEnd();
                compileApplication.WaitForExit();
                compileApplication.Close();
                Console.WriteLine($"Cl compiler output:\n{output}");
                if (output.ToLower().Contains("fatal") || output.ToLower().Contains("error"))
                {
                    return false;
                }
                else if (output.ToLower().Contains("usage"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("The build did not fail however, no files were provided to the compiler.");
                    Console.ResetColor();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static string GenerateCommand(ReadableInstructions[] instructions)
        {
            string clCommand = "cl.exe /EHsc";
            foreach (ReadableInstructions instruction in instructions)
            {
                if (instruction.type == ReadableInstructionType.Header)
                {
                    string fileName = instruction.fullpath.Replace(".hpp", "");
                    clCommand += $@" /I .\{fileName}\";
                }
                else
                {
                    continue;
                }
            }
            foreach (ReadableInstructions instruction in instructions)
            {
                if(instruction.type == ReadableInstructionType.Source)
                {
                    string fileName = instruction.fullpath.Replace(".cpp", "");
                    clCommand += $@" .\{fileName}.cpp";
                }
                else
                {
                    continue;
                }
            }
            return clCommand;
        }
    }

    public struct ReadableInstructions
    {
        public string fullpath { get; }
        public ReadableInstructionType type { get; }

        public ReadableInstructions(string fullpath, ReadableInstructionType type)
        {
            this.fullpath = fullpath;
            this.type = type;
        }
    }

    public enum ReadableInstructionType
    {
        Header,
        Source,
    }
}

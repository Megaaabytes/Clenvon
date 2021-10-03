using System;
using System.Collections.Generic;
using System.IO;

namespace Clenvon.Parsing
{
    public class ParseFile
    {
        public static Instructions[] BeginParse(string file)
        {
            List<Instructions> instructions = new List<Instructions>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if(line == "compile") // skips any extra lines that maybe useless lines such as \n lines.
                {
                    Instructions newInstruct = new Instructions(InstructionType.Compile, null);
                    instructions.Add(newInstruct);
                    break;
                }
                if (line.Contains("add-class"))
                {
                    string data = GetData(line.Remove(0, 9));
                    Instructions newInstruct = new Instructions(InstructionType.AddClass, data);
                    instructions.Add(newInstruct);
                }
                else if (line.Contains("add-header-directory"))
                {
                    string data = GetData(line.Remove(0, 10));
                    Instructions newInstruct = new Instructions(InstructionType.AddHeaderDirectory, data);
                    instructions.Add(newInstruct);
                }
                else if (line.Contains("project"))
                {
                    string data = GetData(line.Remove(0, 7));
                    Instructions newInstruct = new Instructions(InstructionType.Project, data);
                    instructions.Add(newInstruct);
                }
                else
                {
                    Console.WriteLine($"[FATAL ERROR] Unrecognized command '{line}'");
                    return new List<Instructions>().ToArray();
                }
            }
            return instructions.ToArray();
        }

        private static string GetData(string line)
        {
            bool beginGettingCharacters = false;
            string finalResult = null;

            foreach(char ch in line)
            {
                if(ch.ToString() == "(")
                {
                    beginGettingCharacters = true;
                }
                else if(ch.ToString() == ")")
                {
                    break;
                }
                else
                {
                    if(beginGettingCharacters == true)
                    {
                        finalResult += ch.ToString();
                    }
                }
            }
            return finalResult;
        }
    }

}

public struct Instructions
{
    public InstructionType type { get; }
    public string data { get; }

    public Instructions(InstructionType type, string data)
    {
        this.type = type;
        this.data = data;
    }
}

public enum InstructionType
{
    AddHeaderDirectory,
    AddClass,
    Project,
    Compile,
}

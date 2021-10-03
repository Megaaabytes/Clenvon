using System;
using Clenvon.IO;
using Clenvon.Misc;
using Clenvon.Parsing;
using Clenvon.Instruction;

namespace Clenvon
{
    class Program
    {
        static void Main(string[] args)
        {
            if (GetCompilerDirectory.GetDirectory() == "File not found")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Clenvon requires the Visual Studio 2019 Developer Tools command prompt to work properly. The dependency was not found on your computer.");
                Console.ResetColor();
                Environment.Exit(0);
            }
            Console.WriteLine("Welcome to Clenvon 2021 Version 1.0.2!\n");
            while (true)
            {
                Console.Write("Clenvon $ ");
                string command = Console.ReadLine();
                if (command.Contains("compile"))
                {
                    Console.WriteLine("Compiling files please wait...");
                    Timer timer = new Timer();
                    timer.StartTimer();
                    bool success = GetFile.CheckFiles(command.Remove(0, 7).Replace(" ", ""));
                    if (success == false)
                    {
                        string time = timer.StopTimer();
                        Console.Write("\n[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("BUILD FAILED");
                        Console.ResetColor();
                        Console.Write("] ");
                        Console.WriteLine($"{time} seconds.");
                    }
                    else
                    {
                        Instructions[] instructions = ParseFile.BeginParse(command.Remove(0, 7).Replace(" ", ""));
                        bool filesExist = InstructionChecker.CheckInstructionsForErrors(instructions);
                        if (filesExist == false)
                        {
                            Console.WriteLine("Something was wrong with the instructions in the file.");
                            string time = timer.StopTimer();
                            Console.Write("\n[");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("BUILD FAILED");
                            Console.ResetColor();
                            Console.Write("] ");
                            Console.WriteLine($"{time} seconds.");
                        }
                        else
                        {
                            ReadableInstructions[] readableInstructs = InstructionTools.CreateReadableInstructions(instructions);
                            bool success1 = InstructionTools.BeginCompiling(readableInstructs);
                            if(success1 == true)
                            {
                                string time = timer.StopTimer();
                                Console.Write("\n[");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("BUILD SUCCESS");
                                Console.ResetColor();
                                Console.Write("] ");
                                Console.WriteLine($"{time} seconds.");
                            }
                            else
                            {
                                string time = timer.StopTimer();
                                Console.Write("\n[");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("BUILD FAILED");
                                Console.ResetColor();
                                Console.Write("] ");
                                Console.WriteLine($"{time} seconds.");
                            }
                        }
                    }
                }
                else if(command == "exit")
                {
                    Console.WriteLine("Exiting Clenvon...");
                    Environment.Exit(0);
                }
                else if(command == "ver")
                {
                    Console.WriteLine("Installed Clenvon version: 1.0.2");
                }
                else if(command == "clear")
                {
                    Console.Clear();
                }
                else if(command == "about")
                {
                    Console.WriteLine("Clenvon 2021, Version 1.0.2");
                    Console.WriteLine("Repository: https://github.com/megaaabytes/clenvon");
                    Console.WriteLine("Author: Megaaabytes");
                    Console.WriteLine("Clenvon source code is licensed under GNU LGPL 2.1.");
                    Console.WriteLine($"Visual Studio Developer Tools is located at: {GetCompilerDirectory.GetDirectory()}");
                }
                else if(command == "help")
                {
                    Console.WriteLine("Clenvon Help");
                    Console.WriteLine("Compile - <clenvon project text file>");
                    Console.WriteLine("exit - Exits Clenvon.");
                    Console.WriteLine("ver - displays Clenvon version");
                    Console.WriteLine("about - displays data about Clenvon.");
                    Console.WriteLine("help - shows command usages.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unrecognized command.");
                    Console.ResetColor();
                }
            }
        }
    }
}

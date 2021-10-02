# Clenvon
Clenvon stands for C Language Environment

Clenvon is a small C# application which assists with the visual studio c/c++ compiler.

# Prerequisites
.NET Core

Visual Studio 2019 Developer Tools for the cl.exe.

# Usage
First, you'll need to create a document which will be able to compile your application. To do this, create a blank text file somewhere on your Desktop or somewhere on your computer. You can call this file 'clenvon-environment-example.txt' as an example. Inside the text file, write project(). Inside the parenthesis, write the root directory of your project. Example: C:\Users\exampleuser\exampleprogram. Then on the next line, write add-class(). Inside the parenthesis, write the name of the class file. Example, main.cpp. Finally, make a new line and type 'compile'. This will tell Clenvon to get CL.exe ready for compiling your project.
  
Now, open Clenvon. Clenvon as of right does not support command line arguments but still can be opened inside cmd, powershell, etc. In Clenvon, type the word 'compile <directory of the text file you just created>'. Then press enter. Thats it, Clenvon will read the text file and send the arguments to cl.exe and your program will be compiled!
  
# Visual Examples
https://github.com/Megaaabytes/Clenvon/blob/17228d69624993d58384392c336764ff9d7f2de9/images/clenvon-example.png

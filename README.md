# Clenvon
Clenvon stands for C Language Environment

Clenvon is a small C# application which assists with the visual studio c/c++ compiler. This application will only help with compiling C++ applications. It does not support C.

# Prerequisites
.NET Core

Visual Studio 2019 Developer Tools for the C/C++ Compiler.

# Usage
First, you'll need to create a document which will be able to compile your application. To do this, create a blank text file somewhere on your Desktop or somewhere on your computer. You can call this file 'clenvon-environment-example.txt' as an example. Inside the text file, write project(). Inside the parenthesis, write the root directory of your project. Example: C:\Users\exampleuser\exampleprogram. Then on the next line, write add-class(). Inside the parenthesis, write the name of the class file. Example, main.cpp. Finally, make a new line and type 'compile'. This will tell Clenvon to get CL.exe ready for compiling your project.
  
Now, open Clenvon. Clenvon as of right does not support command line arguments but still can be opened inside cmd, powershell, etc. In Clenvon, type the word 'compile < path of your clenvon text file >'. Then press enter. Thats it, Clenvon will read the text file and send the arguments to cl.exe and your program will be compiled!

# Adding Headers
To add header files to your Clenvon script, open your Clenvon script in a text editor and under the 'compile' block, insert a new block called 'add-header()', inside the parenthesis, add the header file name. For example, 'add-header(main.hpp)'. Thats it. You successfully added a header to your script! Just click save and run the compile command in the Clenvon application.
  
# Adding multiple Headers in one line
You've seen how to initalize your project directory, add classes and header files one by one. But lets you say you a project with possibly hundreds of header files. You probably don't want to add 'add-header(file-name)' for every file. I certainly won't. This is time consuming and wastes space on your computer. Instead of this, you can use one line, however this will only work if all your header files are placed in one directory. Usually called 'include'. If your header files are in a separate directory, this won't work as this command can only be used once. To do this, Open your Clenvon script in a text editor and add a new line and enter 'include-directory()'. Inside the parenthesis, add the name of the directory. You do not need to enter the full path. Just the folder name. For example, 'include-directory(include)'. Thats it, any file inside that directory will be marked as a header file and will be added to compiler arguments!
  
# Visual Examples
![Alt text](/images/clenvon-example.png?raw=true)
![Alt text](/images/compile-example.png?raw=true)

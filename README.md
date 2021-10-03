# Clenvon
A small C# application which assists with the visual studio c/c++ compiler. This program only supports C++ projects at the moment and does not support command line arguments yet.

# Prerequisites
.NET Core

Visual Studio 2019 Developer Tools

# Usage
Create an empty text document somewhere on your computer. Ensure you memorize its location. Inside that text file, on the first line type 'project()'. Inside the parenthesis,
enter the path of the directory used by your C++ project. Next, below your project block, enter the word 'compile'. That's it! You've successfully created your script, but it doesn't do anything yet.

# Adding Classes and giving your script a use
Inside your text document, between the project and compile blocks. Create a new a block called 'add-class()'. Inside the parenthesis, add the name of class file. An example of this is, 'add-class(program.cpp)'. If your class is not in the directory the project block specifies, an example is 'add-class(exampledirectory/examplefile.cpp)'. But ensure, cl.exe can recognize that directory.
After running the script inside Clenvon, it would compile!

# Adding Headers
Inside your text document, somewhere between your project and compile blocks. Create a new block called 'add-header-directory()'. Inside the parenthesis, add the directory name of where the header files are located. An example of this is 'add-header-directory(include)' or if the directory is in another directory, 'add-header-directory(stuff/include)'.
Once you run your script inside Clenvon, Clenvon will detect your headers automatically!

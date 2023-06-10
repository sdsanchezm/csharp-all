using System.IO;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("working with file system");


// list the names of the top-level directories,
IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

foreach (var dir in listOfDirectories) {
    Console.WriteLine(dir);
}

// list the names of all of the files in a directory
IEnumerable<string> files = Directory.EnumerateFiles("stores");

foreach (var file in files)
{
    Console.WriteLine(file);
}

// Find all *.txt files in the stores folder and its subfolders
IEnumerable<string> allFilesInAllFolders = Directory.EnumerateFiles("stores", "*.txt", SearchOption.AllDirectories);

foreach (var file in allFilesInAllFolders)
{
    Console.WriteLine(file);
}

var salesFiles = FindFiles("stores");
    
foreach (var file in salesFiles)
{
    Console.Write("file: ");
    Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

Console.WriteLine(Directory.GetCurrentDirectory());
// it returns my documents in the home folder in windows
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
Console.WriteLine(docPath);
// the separator here, because it might be different OS
Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// combine the text to access 2 folders
Console.WriteLine(Path.Combine("stores","201")); // outputs: stores/201

// outputs: .json
Console.WriteLine(Path.GetExtension("sales.json"));

string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
FileInfo info = new FileInfo(fileName);
Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");


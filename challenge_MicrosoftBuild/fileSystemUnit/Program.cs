using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

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

// check if a dir exists:
// bool doesDirectoryExist = Directory.Exists(filePath);
bool doesDirectoryExist = Directory.Exists("stores");
Console.WriteLine(doesDirectoryExist);

// create directory newDir in the folder: stores/201
Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));

// Create Files:
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hallo Welt!!");

// Exercies:
// get the current dir:
var currentDirectory = Directory.GetCurrentDirectory();
// add the stores folder to the variable storesDirectory
var storesDirectory = Path.Combine(currentDirectory, "stores");
// add the stores folder to the variable salesTotalDir:s
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
// create tje salesTotalDir directory
Directory.CreateDirectory(salesTotalDir);
// find files within storesDirectory
// var salesFiles = FindFiles(storesDirectory);
// create the totals.txt file and include an empty string within it. 
File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

// Read files:
File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
Console.WriteLine(File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json"));

// Read the text from a specific file
var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// Deserialize, using the newtonsoft library
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// print the total (only the number), because it's a json object with in the .json file
Console.WriteLine(salesData.Total);




var data1 = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data1.Total.ToString());

System.Console.WriteLine("the end");

var data2 = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data2.Total}{Environment.NewLine}");



// ==

currentDirectory = Directory.GetCurrentDirectory();
var storesDir = Path.Combine(currentDirectory, "stores");

salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

salesFiles = FindFiles2(storesDir);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles2(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // READ FILES LOOP
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}


class SalesTotal
{
  public double Total { get; set; }
}

record SalesData (double Total);

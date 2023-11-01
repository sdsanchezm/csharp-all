// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Threading.Channels;

namespace SystemIO
{
    public class Program 
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("=====================File and FileInfo");

            var actualPath1 = @"c:\progs\temp\temp1\a.txt";
            var actualPath2 = @"c:\progs\temp\temp2\b.txt";
            var actualPath3 = @"c:\progs\temp\temp2\c.txt";

            //File.Create(actualPath1);

            File.Copy(actualPath1, actualPath2, true);
            if (File.Exists( actualPath1 ) )
            {
                Console.WriteLine("path1 exists!");
            }

            var content = File.ReadAllText(actualPath1);

            if (File.Exists(actualPath2))
            {
                Console.WriteLine("path2 exists!");
            }

            var content1 = File.ReadAllBytes(actualPath1);

            var fileInfo = new FileInfo(actualPath1);
            fileInfo.CopyTo(actualPath3);
            //fileInfo.Delete();
            if(fileInfo.Exists )
            {
                Console.WriteLine("exists!");
            }

            Console.WriteLine("=====================Directory and DirectoryInfo");

            var newPath1 = @"c:\progs\temp\temp3";
            var existingPath1 = @"c:\progs\temp\temp2";
            var existingPath2 = @"c:\progs\temp\";

            Directory.CreateDirectory(newPath1);

            var files1 = Directory.GetFiles(existingPath1, "*.*", SearchOption.AllDirectories);

            foreach ( var file1 in files1 )
            {
                Console.WriteLine(file1);
            }

            // only directories
            //var directories = Directory.GetDirectories(existingPath2, "*.*", SearchOption.AllDirectories);
            var directories = Directory.GetDirectories(existingPath2, "*.*", SearchOption.TopDirectoryOnly);
            foreach ( var directory in directories )
                Console.WriteLine(directory);

            // check if a directory exists
            Directory.Exists(newPath1);

            var directoryInfo = new DirectoryInfo("...");
            directoryInfo.GetFiles(newPath1);
            directoryInfo.GetDirectories(newPath1);

            Console.WriteLine("=====================Path");

            var path1 = @"C:\progs\temp\temp1\a.txt";

            var dotIndex = path1.IndexOf('.');
            var extension = path1.Substring(dotIndex + 1);

            Console.WriteLine($"GetExtension: {Path.GetExtension(path1)}");
            Console.WriteLine($"GetFileName: {Path.GetFileName(path1)}");
            Console.WriteLine($"GetFileNameWithoutExtension: {Path.GetFileNameWithoutExtension(path1)}");
            Console.WriteLine($"GetDirectoryName: {Path.GetDirectoryName(path1)}");
        }
    }
}
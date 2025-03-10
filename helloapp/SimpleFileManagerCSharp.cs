namespace SimpleFileManagerCSharp;
using System;
using System.IO;
class FileManager
{
    private string currentDirectory;

    public FileManager()
    {
        currentDirectory = Directory.GetCurrentDirectory();
    }

  // Просмотр файловой структуры
      public void ListFiles()
    {
        Console.WriteLine("Contents of " + currentDirectory);
        foreach (var file in Directory.GetFiles(currentDirectory))
        {
            Console.WriteLine(Path.GetFileName(file));
        }
        foreach (var dir in Directory.GetDirectories(currentDirectory))
        {
            Console.WriteLine(Path.GetFileName(dir));
        }
    }
 // переход между каталогами 
    public void ChangeDirectory(string newDirectory)
    {
        string path = Path.Combine(currentDirectory, newDirectory);
        if (Directory.Exists(path))
        {
            currentDirectory = path;
            Console.WriteLine("Changed directory to " + currentDirectory);
        }
        else
        {
            Console.WriteLine("Directory not found: " + newDirectory);
        }
    }
    // Копирование файлов и каталогов

    static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
{
   
    var dir = new DirectoryInfo(sourceDir);

    if (!dir.Exists) throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}")
    
    DirectoryInfo dirs = dir.GetDirectories();
  
    Directory.CreateDirectory(destinationDir);
   
    foreach (FileInfo file in dir.GetFiles())
    {
        string targetFilePath = Path.Combine(destinationDir, file.Name);
        file.CopyTo(targetFilePath);
    }
    
}
}
// удаление файлов




class Program  
{
    static void Main(string[]args)
    {
        FileManager manager = new FileManager();
        manager.ListFiles();
        manager.ChangeDirectory("folder1");
        manager.ListFiles();
    }
}
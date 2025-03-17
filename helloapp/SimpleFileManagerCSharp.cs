namespace SimpleFileManagerCSharp;
using System;
using System.IO;
class FileManager
{
    private string currentDirectory;
 // выбор пути файла
    public FileManager()
    {
       Console.WriteLine("Выберите путь..");
       string? currentDirectory = Console.ReadLine();
    }
 

  // Просмотр файловой структуры
      public void ListFiles()
    {
        Console.WriteLine("Содержание " + currentDirectory);
         foreach (var file in Directory.GetFiles(currentDirectory))
        {
            Console.WriteLine(Path.GetFileName(file));
        }
         foreach (var dir in Directory.GetDirectories(currentDirectory))
        {
            Console.WriteLine(Path.GetFileName(dir));
        }
    }
   // Переход между каталогами 
    public void ChangeDirectory(string newDirectory)
    {
        string path = Path.Combine(currentDirectory, newDirectory);
         if (Directory.Exists(path))
        {
            currentDirectory = path;
            Console.WriteLine("Изменение каталога на " + currentDirectory);
        }
         else
        {
            Console.WriteLine("Каталог не найден: " + newDirectory);
        }
    }
    // Копирование файлов и каталогов

    static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
   {
   
      var dir = new DirectoryInfo(sourceDir);
 
       if (!dir.Exists) throw new DirectoryNotFoundException($"Исходный каталог не найден: {dir.FullName}");
    
     // DirectoryInfo[] dirs = dir.GetDirectories();
  
      Directory.CreateDirectory(destinationDir);
   
       foreach (FileInfo file in dir.GetFiles())
       {
          string targetFilePath = Path.Combine(destinationDir, file.Name);
          file.CopyTo(targetFilePath);
        }
    
    }

}





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
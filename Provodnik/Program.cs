using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        ShowPapka("/");
    }

    static void ShowPapka(string s)
    {
        while (true)
        {
            try
            {
                Console.Clear();
                string[] paths = Directory.GetDirectories(s);
                foreach (string path in paths)
                {
                    Console.WriteLine("   " + path);
                }

                string[] paths1 = Directory.GetFiles(s);
                foreach (string path1 in paths1)
                {
                    Console.WriteLine("   " + path1);
                }

                DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(s));

                Console.WriteLine($"   Свободное место на диске: {driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");
                Console.WriteLine($"   Всего места на диске: {driveInfo.TotalSize / (1024 * 1024 * 1024)} GB");

                int pos = Strelki.Pokaz(0, paths.Length - 1 + paths1.Length);
                if (pos == -1)
                    return;
                if (pos <= paths.Length)
                    ShowPapka(paths[pos]);
                if (pos >= paths.Length)
                {
                    Process.Start(paths1[pos - paths.Length]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream
{
    class Program
    {
        static void Show()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\СантыбаевХ\Desktop");
            FileInfo[] imageFiles = dir.GetFiles("*.txt", SearchOption.AllDirectories);
            Console.WriteLine("Найдено {0} фалов .txt", imageFiles.Length);
            //Console.WriteLine("инфа о каталоге\n");
            Console.WriteLine("Полный путь: {0}\nНазвание папки: {1}\nРодительский каталог: {2}\n" +
                "Время создания : {3}\nАтрибуты: {4}\nКорневой каталог: {5}",
                dir.FullName, dir.Name, dir.Parent, dir.CreationTime, dir.Attributes, dir.Root);
        }
        static void showInfo()
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach (var item in di)
            {
                Console.WriteLine("AvailableFreeSpace: " + item.AvailableFreeSpace / Math.Pow(1024, 2) + "\nTotalSize: "
                + item.TotalSize / Math.Pow(1024, 2) + "\nDriveFormat: " + item.DriveFormat + "\nDriveType: "
                + item.DriveType + "\nIsReady: " + item.IsReady + "\nName: " + item.Name + "\nRootDirectory: " + item.RootDirectory
                + "\nVolumeLabel: " + item.VolumeLabel);
                Console.WriteLine();
                Console.WriteLine();
            }            
            //foreach (var item in di)
            //{

            //    if (item.DriveType.ToString() == "Removable")
            //    {
            //        Directory.CreateDirectory(item.Name.Remove(1, 2));
            //        using (StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), item.Name.Remove(1, 2), "Info.txt")))
            //        {
            //            writer.WriteLine("AvailableFreeSpace: " + item.AvailableFreeSpace / Math.Pow(1024, 2));
            //            writer.WriteLine("TotalSize: " + item.TotalSize / Math.Pow(1024, 2));
            //            writer.WriteLine("DriveFormat: " + item.DriveFormat);
            //            writer.WriteLine("DriveType: " + item.DriveType);
            //            writer.WriteLine("IsReady: " + item.IsReady);
            //            writer.WriteLine("Name: " + item.Name);
            //            writer.WriteLine("RootDirectory: " + item.RootDirectory);
            //            writer.WriteLine("VolumeLabel: " + item.VolumeLabel);
            //        }


            //    }
            //}
        }
        static void Save()
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            Console.WriteLine("Введите путь:");
            string path = Console.ReadLine();
            Console.WriteLine("Введите имя диска, инормацию о котором вы хотите сохранить: ");
            string choice = Console.ReadLine();
            foreach (var item in di)
            {
                if (item.Name.Remove(1, 2)== choice)
                {
                    Directory.CreateDirectory(item.Name.Remove(1, 2));
                    using (StreamWriter writer = new StreamWriter(Path.Combine(path, "Info.txt")))
                    {
                        writer.WriteLine("AvailableFreeSpace: " + item.AvailableFreeSpace / Math.Pow(1024, 2));
                        writer.WriteLine("TotalSize: " + item.TotalSize / Math.Pow(1024, 2));
                        writer.WriteLine("DriveFormat: " + item.DriveFormat);
                        writer.WriteLine("DriveType: " + item.DriveType);
                        writer.WriteLine("IsReady: " + item.IsReady);
                        writer.WriteLine("Name: " + item.Name);
                        writer.WriteLine("RootDirectory: " + item.RootDirectory);
                        writer.WriteLine("VolumeLabel: " + item.VolumeLabel);
                    }


                }
            }
        }
        static void Main(string[] args)
        {
            //FileInfo f = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "test.dat"));
            //System.IO.FileStream fs = f.Create();
            //fs.Close();
            //Show();

            showInfo();
            Save();
            //записать в текстовый файл дерево 
            //Folder
            //-user.txt
            //Folder1
            //-Folder11
            //-user1.txt



        }
    }
}

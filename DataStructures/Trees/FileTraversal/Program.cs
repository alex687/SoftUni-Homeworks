namespace FileTraversal
{
    using System;
    using System.IO;

    public class Program
    {
        private const string StartFolder = "D:\\Just Cause 2";

        public static void Main()
        {
            Folder root = new Folder(StartFolder);

            RecursiveDirectorySearch(root);

            // In bytes
            Console.WriteLine(root.Size);
        }

        public static void RecursiveDirectorySearch(Folder folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                folder.Files.Add(new File(file.FullName, file.Length));
            }

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Folder newFolder = new Folder(directory.FullName);

                folder.Folders.Add(newFolder);

                RecursiveDirectorySearch(newFolder);
            }
        }
    }
}

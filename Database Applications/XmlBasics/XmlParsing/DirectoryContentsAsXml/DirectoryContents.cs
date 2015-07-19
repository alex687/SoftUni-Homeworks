namespace DirectoryContentsAsXml
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;

    public class DirectoryContents
    {
        private readonly string startPath;

        public DirectoryContents(string path)
        {
            this.startPath = path;
        }

        public void AsXmlUsingXmlWriter(string file)
        {
            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path", this.startPath);
                this.GenerateXmlForFolder(writer, this.startPath);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void AsXmlUsingXDocument(string file)
        {
            var document = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement("root-dir", new XAttribute("path", this.startPath)));

            this.GenerateXmlForFolderXDoc(document.Root, this.startPath);
            document.Save(file);
        }

        private void GenerateXmlForFolderXDoc(XElement document, string path)
        {
            var info = new DirectoryInfo(path);
            DirectoryInfo[] childDirectories = info.GetDirectories();

            foreach (var childDirectory in childDirectories)
            {
                XElement dir = new XElement("dir", new XAttribute("name", childDirectory.Name));
                document.Add(dir);

                this.GenerateXmlForFolderXDoc(dir, childDirectory.FullName);
            }

            var files = info.GetFiles();
            foreach (var file in files)
            {
                XElement filElement = new XElement("file", new XAttribute("name", file.Name));
                document.Add(filElement);
            }
        }
        
        private void GenerateXmlForFolder(XmlWriter writer, string path)
        {
            var info = new DirectoryInfo(path);
            DirectoryInfo[] childDirectories = info.GetDirectories();

            foreach (var childDirectory in childDirectories)
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", childDirectory.Name);

                this.GenerateXmlForFolder(writer, childDirectory.FullName);
                writer.WriteEndElement();
            }

            var files = info.GetFiles();
            foreach (var file in files)
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }
        }
    }
}

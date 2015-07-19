namespace DirectoryContentsAsXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startPath = "C:\\maven";
            var dirContents = new DirectoryContents(startPath);

            var file = "../../directory-content.xml";
            dirContents.AsXmlUsingXDocument(file);
        }
    
    }
}

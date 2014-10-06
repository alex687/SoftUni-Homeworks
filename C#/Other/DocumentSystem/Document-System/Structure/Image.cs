namespace DocumentSystem.Structure
{
    using System.IO;

    public class Image : Element
    {
       public Image(ImageType type, byte[] data)
        {
            this.Type = type;
            this.Data = data;
        }

       public ImageType Type { get; set; }

       public byte[] Data { get; set; }

        public static Image CreateFromFile(string fileName)
        {
            ImageType type = ImageType.CreateFromFileName(fileName);
            byte[] data = File.ReadAllBytes(fileName);
            Image image = new Image(type, data);
            return image;
        }
    }
}

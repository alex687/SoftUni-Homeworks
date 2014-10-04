using System;
using System.IO;

namespace DocumentSystem.Structure
{
    public class Image : Element
    {
        public ImageType Type { get; set; }
        public byte[] Data { get; set; }

        public Image(ImageType type, byte[] data)
        {
            this.Type = type;
            this.Data = data;
        }

        public static Image CreateFromFile(string fileName)
        {
            ImageType type = ImageType.CreateFromFileName(fileName);
            byte[] data = File.ReadAllBytes(fileName);
            Image image = new Image(type, data);
            return image;
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("[image]");
        }
    }
}

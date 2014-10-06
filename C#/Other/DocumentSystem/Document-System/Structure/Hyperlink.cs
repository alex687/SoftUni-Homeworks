namespace DocumentSystem.Structure
{
    using System.IO;

    public class Hyperlink : CompositeElement
    {
        public Hyperlink(string url)
        {
            this.Url = url;
        }

        public Hyperlink(string url, string text)
        {
            this.Url = url;
            this.Add(new TextElement(text));
        }
        
        public string Url { get; set; }
    }
}

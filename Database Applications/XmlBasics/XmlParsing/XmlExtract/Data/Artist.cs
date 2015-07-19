namespace XmlExtract.Data
{
    using System.Collections.Generic;

    public class Artist
    {
        public Artist()
        {
            this.Albums = new List<Album>();
        }

        public string Name { get; set; }

        public List<Album> Albums { get; set; }
    }
}

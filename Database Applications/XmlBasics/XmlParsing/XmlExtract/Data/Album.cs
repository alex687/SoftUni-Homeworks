namespace XmlExtract.Data
{
    using System.Collections.Generic;

    public class Album
    {
        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public string Description { get; set; }

        public string LinkDescription { get; set; }
    }
}

namespace XmlExtract
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using XmlExtract.Data;

    public class XmlCatalog
    {
        public XDocument Document { get; private set; }

        public XmlCatalog()
        {
            this.Document = XDocument.Load("../../catalog.xml");
        }

        public List<Artist> ExtractData()
        {
            var element = this.Document.Root;
            if (element != null)
            {
                var artists = new List<Artist>();
                foreach (var artistXml in element.Elements())
                {
                    var artist = new Artist { Name = artistXml.Attribute("name").Value };

                    var albumsXml = artistXml.Elements();
                    var albums = this.GetArtistAlbums(albumsXml);
                    artist.Albums = albums;

                    artists.Add(artist);
                }

                return artists;
            }

            return null;
        }

        private List<Album> GetArtistAlbums(IEnumerable<XElement> albumsXml)
        {
            var albums = new List<Album>();
            foreach (var albumXml in albumsXml)
            {
                var album = new Album();
                album.Name = albumXml.Attribute("title").Value;
                album.Songs = albumXml.Descendants("song").Select(s => new Song { Title = s.Attribute("title").Value, Length = s.Attribute("length").Value }).ToList();

                var descriptionXml = albumXml.Element("description");
                if (descriptionXml != null)
                {
                    album.Description = descriptionXml.Value;
                    album.Description = descriptionXml.Attribute("link").Value;
                }

                albums.Add(album);
            }

            return albums;
        }
    }
}

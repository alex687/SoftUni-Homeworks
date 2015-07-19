namespace XmlExtract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using XmlExtract.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var catalog = new XmlCatalog();
            var artists = catalog.ExtractData();

            #region Problem 2.	DOM Parser: Extract Album Names
            var artistsAlbumsNames = artists.Select(a => string.Join(",", a.Albums.Select(alb => alb.Name).ToList())).ToList();
            Console.WriteLine("[" + string.Join(",", artistsAlbumsNames) + "]");
            #endregion

            #region Problem 3.	DOM Parser: Extract All Artists Alphabetically
            var artistsNames = artists.Select(a => a.Name).ToList();
            var setArtistsNames = new HashSet<string>(artistsNames);
            Console.WriteLine("[" + string.Join(",", setArtistsNames) + "]");
            #endregion

            #region Problem 4.	DOM Parser: Extract Artists and Number of Albums

            var artistsNumberAlbums = new Dictionary<string, int>();
            foreach (var artist in artists)
            {
                var artistName = artist.Name;
                var albumsNumber = artist.Albums.Count();

                artistsNumberAlbums.Add(artistName, albumsNumber);
            }

            var artistsNumberAlbumsStr = artistsNumberAlbums.Select(a => a.Key + ":" + a.Value).ToList();
            Console.WriteLine("[" + string.Join(",", artistsNumberAlbumsStr) + "]");

            #endregion

            #region Problem 5.	XPath: Extract Artists and Number of Albums
            var artistsNamesNumberAlbums =
                catalog.Document.Document.XPathSelectElements("/music/artist")
                    .ToDictionary(a => a.Attribute("name").Value, a => a.Elements("album").Count());

            artistsNumberAlbumsStr = artistsNamesNumberAlbums.Select(a => a.Key + ":" + a.Value).ToList();
            Console.WriteLine("[" + string.Join(",", artistsNumberAlbumsStr) + "]");
            #endregion

            #region Problem 6.	DOM Parser: Delete Albums
            var elements = catalog.Document.XPathSelectElements("music/artist/album[@price > 20]");
            elements.Remove();
            catalog.Document.Save("../../cheap-albums-catalog.xml");
            #endregion

            #region Problem 7.	DOM Parser and XPath: Old Albums
            catalog = new XmlCatalog();
            DateTime date = DateTime.Now;
            date = date.AddYears(-5);

            var query = string.Format("music/artist/album[number(translate(@pub-date,'-',''))  < {0}]", date.ToString("yyyyMMdd"));

            catalog.Document.XPathSelectElements(query).Remove();
            var artistsOldAlbums = catalog.ExtractData();

            var albumsNames = artistsOldAlbums.Select(a =>  string.Join(",", a.Albums.Select(alb => alb.Name).ToList())).ToList();
            Console.WriteLine("[" + string.Join(",", albumsNames) + "]");
            #endregion

            #region Problem 8.	LINQ to XML: Old Albums
            catalog = new XmlCatalog();
            var albumsNamesPrices = from album in catalog.Document.Root.Elements("album")
                          where DateTime.Parse(album.Attribute("pub-date").Value) > date
                          select
                              new { Title = album.Attribute("title").Value, Price = album.Attribute("price").Value };
           
            Console.WriteLine("[" + string.Join(",", albumsNames) + "]");
            #endregion
        }
    }
}

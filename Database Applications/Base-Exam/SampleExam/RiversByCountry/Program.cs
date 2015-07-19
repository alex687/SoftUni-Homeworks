namespace RiversByCountry
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    using Geography.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument queryXml = XDocument.Load("../../rivers-query.xml");
            var queries = queryXml.Root.Elements();

            using (XmlWriter writer = XmlWriter.Create("../../results.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("results");
               
                var geographyData = new GeographyData();
                foreach (var query in queries)
                {
                    var countries = query.Elements("country").Select(country => country.Value).ToList();

                    var riversQuery = geographyData.Rivers.AsQueryable();
                    riversQuery =
                        countries.Aggregate(
                            riversQuery,
                            (current, country) => current.Where(r => r.Countries.Any(c => c.CountryName == country)))
                            .OrderBy(r => r.RiverName);

                    var riverNamesQuery = riversQuery.Select(r => r.RiverName);
                    var totalCount = riverNamesQuery.Count();
                    
                    var maxResults = query.Attribute("max-results");
                    if (maxResults != null)
                    {
                        riverNamesQuery = riverNamesQuery.Take(int.Parse(maxResults.Value));
                    }

                    var riverNames = riverNamesQuery.ToList();
                    var listedCount = riverNames.Count();
                    
                    writer.WriteStartElement("rivers");
                    writer.WriteAttributeString("total-count", totalCount.ToString());
                    writer.WriteAttributeString("listed-count", listedCount.ToString());

                    foreach (var riverName in riverNames)
                    {
                        writer.WriteStartElement("river");
                        writer.WriteAttributeString("name", riverName);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}

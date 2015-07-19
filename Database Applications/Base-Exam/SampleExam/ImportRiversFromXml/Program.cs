namespace ImportRiversFromXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using Geography.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument riversDocument = XDocument.Load("../../rivers.xml");
            var context = new GeographyData();

            if (riversDocument.Root != null)
            {
                var riversXml = riversDocument.Root.Elements();
                foreach (var riverXml in riversXml)
                {
                    var river = new River
                                    {
                                        RiverName = riverXml.Elements("name").First().Value,
                                        Length = int.Parse(riverXml.Elements("length").First().Value),
                                        Outflow = riverXml.Elements("outflow").First().Value
                                    };

                    var drainageArea = riverXml.Descendants("drainage-area").FirstOrDefault();
                    if (drainageArea != null)
                    {
                        river.DrainageArea = int.Parse(drainageArea.Value);
                    }

                    var averageDischarge = riverXml.Descendants("average-discharge").FirstOrDefault();
                    if (averageDischarge != null)
                    {
                        river.AverageDischarge = int.Parse(averageDischarge.Value);
                    }

                    // Parse the countries for the river
                    var countryNodes = riverXml.XPathSelectElements("countries/country");
                    foreach (var countryNode in countryNodes)
                    {
                        var country = context.Countries.
                            FirstOrDefault(c => c.CountryName == countryNode.Value);
                        if (country == null)
                        {
                            throw new Exception("Can not find country: " + countryNode.Value);
                        }

                        river.Countries.Add(country);
                    }

                    context.Rivers.Add(river);
                    context.SaveChanges();
                }
            }
        }
    }
}


namespace ExportMonastiersAsXml
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Geography.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var geographyData = new GeographyData();
            var data = geographyData.Countries.Include("Monasteries")
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                                 {
                                     Country = new { Name = c.CountryName }, 
                                     Monasteries = c.Monasteries
                                        .OrderBy(m => m.Name)
                                        .Select(m => new { m.Name })
                                 }).ToList();

            List<dynamic> newData = new List<dynamic>();
            foreach (var item in data)
            {
                newData.Add(item);
            }

            var exporter = new ExportToXml(newData);
            exporter.ExportDataToFile("monasteries.xml");

        }
    }
}

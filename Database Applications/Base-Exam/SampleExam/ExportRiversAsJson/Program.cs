namespace ExportRiversAsJson
{
    using System.IO;
    using System.Linq;

    using Geography.Data;

    using Newtonsoft.Json;

    public class Program
    {
        public static void Main(string[] args)
        {
            var geographyData = new GeographyData();
            
            var riversData =
                geographyData.Rivers.Include("Countries")
                    .OrderBy(r => r.Length)
                    .Select(
                        r =>
                        new
                        {
                            riverName = r.RiverName, 
                            riverLength = r.Length, 
                            countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName)
                        });

            var jsonData = JsonConvert.SerializeObject(riversData);
            File.WriteAllText("rivers.json", jsonData);
        }
    }
}

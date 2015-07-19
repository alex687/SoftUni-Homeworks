namespace ImportMountainsAndPeaksFromJson
{
    using System.Collections.Generic;
    using System.IO;

    using MountainsCodeFirst.Models;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var mountaisJson = JArray.Parse(File.ReadAllText(@"../../mountains.js"));

            foreach (var mountainJson in mountaisJson)
            {
                var peaks = mountainJson["peaks"].Children();
                foreach (var peak in peaks)
                {
                    var p = peak["peakName"].Value<>();
                }
            }
        }

        
    }
}

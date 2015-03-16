namespace Ads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Ads.DB;

    public class Program
    {
        public static void Main(string[] args)
        {
            #region Problem 1.	Show Data from Related Tables
            using (var db = new AdsEntities())
            {
                ConsolePrintAds(DataFromRelatedTables.WithoutInclude(db));
            }

            using (var db = new AdsEntities())
            {
                ConsolePrintAds(DataFromRelatedTables.WithInclude(db));
            }
            #endregion

            #region Problem 2.	Play with ToList()

            using (var db = new AdsEntities())
            {
                var adsSlow = db.Ads.ToList()
                    .Where(a => a.AdStatus.Status == "Published")
                    .OrderBy(a => a.Date)
                    .ToList()
                    .Select(a => new { a.Title, a.Category, a.Town });
            }


            using (var db = new AdsEntities())
            {
                var adsSlow = db.Ads
                    .Where(a => a.AdStatus.Status == "Published")
                    .OrderBy(a => a.Date)
                    .Select(a => new { a.Title, a.Category, a.Town })
                    .ToList();
            }
            
            #endregion

            #region Problem 3.	Select Everything vs. Select Certain Columns

            using (var db = new AdsEntities())
            {
                var adsTitle = db.Ads.Select(a => new { a.Title }).ToList();
            }


            using (var db = new AdsEntities())
            {
                var adsTitle = db.Ads.ToList();
            }

            #endregion
        }

        private static void ConsolePrintAds(List<Ad> ads)
        {
            var typeOfAd = typeof(Ad);
            const string Spacing = "   ";
            foreach (var ad in ads)
            {
                Console.WriteLine(ad.Title);
                Console.WriteLine(Spacing + ad.AspNetUser.UserName);
                Console.WriteLine(Spacing + ad.AdStatus.Status);

                if (ad.Town != null)
                {
                    Console.WriteLine(Spacing + ad.Town.Name);
                }

                if (ad.Category != null)
                {
                    Console.WriteLine(Spacing + ad.Category.Name);
                }
            }
        }
    }
}

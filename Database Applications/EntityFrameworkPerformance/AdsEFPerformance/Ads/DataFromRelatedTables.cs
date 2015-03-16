namespace Ads
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Ads.DB;

    public static class DataFromRelatedTables
    {
        public static List<Ad> WithoutInclude(AdsEntities db)
        {
            return db.Ads.ToList();
        }

        public static List<Ad> WithInclude(AdsEntities db)
        {
            return
                db.Ads.Include(a => a.AdStatus)
                .Include(a => a.AspNetUser)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .ToList();
        }
    }
}
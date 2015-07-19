namespace Bookmarks.Infrastructure.CacheService
{
    using System;
    using System.Web;

    public class BaseCacheService
    {
        protected T Get<T>(string cacheId, Antlr.Runtime.Misc.Func<T> getItemcallback) where T : class
        {
            var item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemcallback();
                HttpContext.Current.Cache.Insert(cacheId, item, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
                return item;
            }

            return item;
        }
    }
}
namespace Twitter.Web
{
    using System.Web.Mvc;

    public class ViewEngineConfig
    {
        internal static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
           viewEngines.Clear();
            viewEngines.Add(new RazorViewEngine());
        }
    }
}
namespace SportSystem.Web
{
    using System.Web.Mvc;

    public class ViewConfig
    {
        internal static void RegisterViews(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();

            viewEngines.Add(new RazorViewEngine());
        }
    }
}
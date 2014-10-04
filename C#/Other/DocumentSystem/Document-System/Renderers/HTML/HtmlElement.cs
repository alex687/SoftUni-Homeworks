using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public abstract class HtmlElement : IHtmlRenderer
    {
        protected Element Element;

        public abstract void RenderHtml(TextWriter writer);
    }
}

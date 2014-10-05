using System.IO;
using DocumentSystem.Structure;

namespace DocumentSystem.Renderers.HTML
{
    public abstract class HtmlElement : IElementRenrer
    {
        protected Element Element;

        public abstract void Render(TextWriter writer);
    }
}

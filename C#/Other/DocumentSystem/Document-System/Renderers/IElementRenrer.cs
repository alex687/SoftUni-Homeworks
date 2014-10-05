using System;
using System.IO;

namespace DocumentSystem.Renderers
{
    public interface IElementRenrer
    {
        void Render(TextWriter writer);
    }
}

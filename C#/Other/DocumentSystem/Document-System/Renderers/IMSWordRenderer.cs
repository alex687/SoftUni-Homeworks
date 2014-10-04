using System;
using System.IO;

namespace DocumentSystem.Renderers
{
    public interface IMSWordRenderer
    {
        void RenderMsWord(Stream stream);
    }
}

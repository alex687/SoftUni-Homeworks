namespace DocumentSystem.Renderers
{
    using System.IO;

    public interface IMSWordRenderer
    {
        void RenderMsWord(Stream stream);
    }
}

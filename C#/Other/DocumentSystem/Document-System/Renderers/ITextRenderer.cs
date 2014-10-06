namespace DocumentSystem.Renderers
{
    using System.IO;

    public interface ITextRenderer
    {
        void RenderText(TextWriter writer);
    }
}

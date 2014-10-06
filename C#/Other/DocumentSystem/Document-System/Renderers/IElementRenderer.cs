namespace DocumentSystem.Renderers
{
    using System.IO;
   
    public interface IElementRenderer
    {
        void Render(TextWriter writer);
    }
}

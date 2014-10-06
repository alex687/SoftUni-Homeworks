namespace DocumentSystem.Renderers.HTML
{
    using System.IO;
    using Structure;

    public class HtmlColor : IElementRenderer
    {
        private Color color;

        public HtmlColor(Color color)
        {
            this.color = color;
        }

        public void Render(TextWriter writer)
        {
            writer.Write("#" +
                this.color.RedValue.ToString("X2") +
                this.color.GreenValue.ToString("X2") +
                this.color.BlueValue.ToString("X2"));
        }
    }
}

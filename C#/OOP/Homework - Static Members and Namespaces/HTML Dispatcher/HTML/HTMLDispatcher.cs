namespace HTML
{
    public static class HTMLDispatcher
    {
        public static ElementBuilder CreateImage(string src, string alt, string title)
        {
            var img = new ElementBuilder("img", true);
            img.AddAttribute("src", src);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);

            return img;
        }

        public static ElementBuilder CreateInput(string type, string name, string value)
        {
            var input = new ElementBuilder("input", true);
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);

            return input;
        }

        public static ElementBuilder CreateImageURL(string href, string title, string text)
        {
            var a = new ElementBuilder("a", true);
            a.AddAttribute("href", href);
            a.AddAttribute("title", title);
            a.AddContent(text);

            return a;
        }
    }
}

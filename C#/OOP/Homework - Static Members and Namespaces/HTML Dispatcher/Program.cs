namespace HTML_Dispatcher
{
    using System;
    using HTML;

    public class Program
    {
        public static void Main(string[] args)
        {
            ElementBuilder div =
                new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            
            Console.WriteLine(div * 2);
            Console.WriteLine();
            Console.WriteLine(HTMLDispatcher.CreateImage("http://softuni.bg/design/logo.png", "Logo", "Test"));
            Console.WriteLine();
            Console.WriteLine(HTMLDispatcher.CreateImageURL("http://abv.bg", "bla", "WTF"));
            Console.WriteLine();
            Console.WriteLine(HTMLDispatcher.CreateInput("text", "bla", "WTF"));
        }
    }
}

using System;
using System.IO;
using DocumentSystem.Renderers.HTML;
using DocumentSystem.Renderers.Text;
using DocumentSystem.Structure;

class Program
{
    static void Main()
    {
        Document doc = new Document();
        doc.Title = "My First Document";
        doc.Author = "Nakov";
        doc.Add(new Paragraph("I am a paragraph"));
        doc.Add(new Hyperlink("http://dir.bg"));
        doc.Add(new Paragraph("I am another paragraph"));
        doc.Add(new Heading("Heading 1"));
        Paragraph paragraph = new Paragraph();
        paragraph.Add(new TextElement("Default Font", Font.DefaultFont));
        paragraph.Add(new TextElement(" "));
        paragraph.Add(new TextElement("Second Red", new Font(color: Color.Red)));
        paragraph.Add(new TextElement(" "));
        paragraph.Add(new TextElement("Green Italic", 
            new Font(color: Color.Green, style: FontStyle.Italic)));
        paragraph.Add(new Paragraph());
        paragraph.Add(
            new TextElement("Consolas Bold Blue Italic",
            new Font(
                color: Color.Blue, 
                style: FontStyle.BoldItalic, 
                name: "Consolas")));
        doc.Add(paragraph);
        
        doc.Add(new Heading("Heading 2<br>", 2));

        doc.Add(
            new Hyperlink("http://softuni.bg")
                .Add(Image.CreateFromFile("../../logo.png"))
                .Add(new TextElement("some text"))
        );
        doc.Add(paragraph);

        var htmlDoc = new HtmlDocument(doc);
        var writer = new StringWriter();
        htmlDoc.Render(writer);
        Console.WriteLine(writer.ToString());
        File.WriteAllText("document.html", writer.ToString());

        var txtDoc = new TxtDocument(doc);
        writer = new StringWriter();
        txtDoc.Render(writer);
        Console.WriteLine(writer.ToString());
        File.WriteAllText("document.txt", writer.ToString());
    }
}

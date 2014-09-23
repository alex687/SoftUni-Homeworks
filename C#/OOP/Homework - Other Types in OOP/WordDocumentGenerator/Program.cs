using Novacode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Globalization;

namespace WordDocumentGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            using (WordDocumentGenerator document = new WordDocumentGenerator("Test.docx"))
            {
                document.AddTitle("SoftUni OOP Game Contest",Alignment.center, 30);
                document.AddImage("rpg-game.png", 600, 300);

                var p = document.Document.InsertParagraph();
                p.AppendLine("Softuni is organizing a contest for the best ");
                p.Append("role playing game ").Bold();
                p.Append("from the OOP teamwork projects ");
                p.Append("The winning teams will receive a ");
                p.Append("grand prize").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                p.FontSize(12);

                var p2 = document.Document.InsertParagraph();
                p2.AppendLine("The game should be:");

                var list = new string[] {
                    "Properly structured OOP",
                    "Awesome",
                    "... Very Awesome",
                };
                document.AddList(list, ListItemType.Bulleted);

                var table =  new string[,]
                {
                    {"Team","Game","Pints"},
                    {"-","-","-",},
                    {"-","-","-",},
                    {"-","-","-",},
                };

                document.AddTable(4, 3, table);

                document.AddText("The top 3 teams will receive  a SPECTACULAR prize:", Alignment.center);
                var p3 = document.Document.InsertParagraph();
                p3.Append("A HANDSHAKE FROM NAKOV").Color(Color.Purple)
                    .FontSize(30).UnderlineStyle(UnderlineStyle.singleLine)
                    .Bold();
                p3.Alignment = Alignment.center;

                try
                {
                    document.Save();
                }
                catch(IOException e)
                {
                    Console.WriteLine("The file cannot be saved. Please check if some other program isi using it.");
                }
            }
        }

        private static object WordDocumentGenerator(string p)
        {
            throw new NotImplementedException();
        }
    }
}

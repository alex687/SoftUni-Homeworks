namespace WordDocumentGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Novacode;

    class WordDocumentGenerator : IDisposable
    {
        private DocX document;
 
        public WordDocumentGenerator(string documentName)
        {
            this.document =  DocX.Create(documentName);
        }

        public DocX Document
        {
            get
            {
                return this.document;
            }
        }

        public  void AddTable(int rows, int cols, string[,] content)
        {
            Table table = this.document.AddTable(rows, cols);
            table.Design = TableDesign.MediumShading1Accent1;
            table.Alignment = Alignment.center;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    table.Rows[i].Cells[j].Paragraphs[0].Append(content[i, j]);
                }
            }

            Paragraph p = this.document.InsertParagraph();
            p.InsertTableAfterSelf(table);
        }

        public void AddImage(string link, int width, int height)
        {
            Novacode.Image image = this.document.AddImage(link);

            Picture picture = image.CreatePicture();
            picture.Width = width;
            picture.Height = height;

            Paragraph p1 = this.document.InsertParagraph();
            p1.AppendPicture(picture);
        }

        public void AddList(string[] listItems, ListItemType itemType)
        {
            var list = this.document.AddList(null, 0, itemType);
            foreach (var item in listItems)
            {
                this.document.AddListItem(list, item);
            }

            this.document.InsertList(list);
        }

        public void AddTitle(string titleText, Alignment alignment, int fontSize, bool bold = true)
        {
            Paragraph title = this.document.InsertParagraph();
            title.Append(titleText).FontSize(fontSize);
            title.Alignment = alignment;
            if (bold)
            {
                title.Bold();
            }
        }

        public void AddText(string text, Alignment alignment)
        {
            Paragraph p = this.document.InsertParagraph();
            p.AppendLine(text);
            p.Alignment = alignment;
        }

        public void Save()
        {
             this.document.Save();
        }

        public void Dispose()
        {
            document.Dispose();
        }
    }
}

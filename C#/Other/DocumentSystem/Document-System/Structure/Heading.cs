namespace DocumentSystem.Structure
{
    using System;
    using System.IO;

    public class Heading : Element
    {
        public Heading(string text, int size = 1)
        {
            if (size <= 0 || size > 6)
            {
                throw new ArgumentOutOfRangeException(
                    "size",
                    "The heading size should be in [1...6].");
            }

            this.HeadingSize = size;
            this.Text = text;
        }

        public int HeadingSize { get; set; }
        
        public string Text { get; set; }
    }
}

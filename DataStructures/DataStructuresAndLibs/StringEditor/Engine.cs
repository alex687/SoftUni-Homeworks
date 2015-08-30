namespace StringEditor
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private readonly IStringEditor editor;
        private StringBuilder output;

        public Engine(IStringEditor editor)
        {
            this.editor = editor;
            this.output = new StringBuilder();
        }

        public string Output
        {
            get
            {
               return this.output.ToString();
            }
        }

        public void ParseCommand(string command)
        {
            string[] commandWords = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                this.DispatchCommand(commandWords);
                this.output.AppendLine("OK");
            }
            catch (Exception e)
            {
                this.output.AppendLine("ERROR");
            }
        }

        private void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "APPEND":
                    this.ExecuteAppendCommand(commandWords);
                    break;
                case "INSERT":
                    this.ExecuteInsertCommand(commandWords);
                    break;
                case "DELETE":
                    this.ExecuteDeleteCommand(commandWords);
                    break;
                case "REPLACE":
                    this.ExecuteReplaceCommand(commandWords);
                    break;
                case "PRINT":
                    this.ExecutePrintCommand(commandWords);
                    break;
                default:
                    break;
            }
        }

        private void ExecutePrintCommand(string[] commandWords)
        {
            Console.WriteLine(this.editor.Text);
            this.output.AppendLine(this.editor.Text);
        }

        private void ExecuteReplaceCommand(string[] commandWords)
        {
            int index = int.Parse(commandWords[1]);
            int count = int.Parse(commandWords[2]);
            string text = string.Join(" ", commandWords.Skip(3));

            this.editor.Replace(index, count, text);
        }

        private void ExecuteDeleteCommand(string[] commandWords)
        {
            int index = int.Parse(commandWords[1]);
            int count = int.Parse(commandWords[2]);

            this.editor.Delete(index, count);
        }

        private void ExecuteInsertCommand(string[] commandWords)
        {
            int index = int.Parse(commandWords[1]);
            string text = string.Join(" ", commandWords.Skip(2));

            this.editor.Insert(index, text);
        }

        private void ExecuteAppendCommand(string[] commandWords)
        {
           var text = string.Join(" ", commandWords.Skip(1));
           this.editor.Append(text);
        }
    }
}

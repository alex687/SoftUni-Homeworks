namespace StringEditor
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            IStringEditor stringEditor = new RopeStringEditor();

            var engine = new Engine(stringEditor);

            string line = Console.ReadLine();
            while (line != "END")
            {
                engine.ParseCommand(line);
                line = Console.ReadLine();
            }

            Console.WriteLine(engine.Output);
        }
    }
}

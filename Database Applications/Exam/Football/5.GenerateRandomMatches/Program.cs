namespace GenerateRandomMatches
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using ListAllTeamNames;

    public class Program
    {
        public static void Main(string[] args)
        {
            var xmlParrent = new Stack<string>();
            using (XmlReader reader = new XmlTextReader("../../generate-matches.xml"))
            {
                var context = new FootballEntities();
                var generator = new Generator(context);
                GenerateConfig generateConfig = null;
                int count = 0;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "generate")
                        {
                            generateConfig = new GenerateConfig();
                            var generateCount = reader.GetAttribute("generate-count");
                            if (generateCount != null)
                            {
                                generateConfig.GenerateCount = int.Parse(generateCount);
                            }

                            var maxGoals = reader.GetAttribute("max-goals");
                            if (maxGoals != null)
                            {
                                generateConfig.MaxGoals = int.Parse(maxGoals);
                            }
                        }

                        xmlParrent.Push(reader.Name);
                    }

                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (xmlParrent.Peek())
                        {
                            case "league":
                                generateConfig.League = reader.Value;
                                break;
                            case "start-date":
                                generateConfig.StartDate = DateTime.Parse(reader.Value);
                                break;
                            case "end-date":
                                generateConfig.EndDate = DateTime.Parse(reader.Value);
                                break;
                        }
                    }

                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "generate")
                        {
                            count++;
                            Console.WriteLine("Processiong request #" + count);
                            generator.Generate(generateConfig);
                            Console.WriteLine();
                        }

                        xmlParrent.Pop();
                    }
                }
            }
        }

    }
}

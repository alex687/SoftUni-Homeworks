namespace LINQtoExcel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;

    class Program
    {
        private const string FilePath = "\\data\\Students-data.txt";
        private const bool SkipFirstLineDocument = true;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;


            IList<Student> students = new List<Student>();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directoryName = Path.GetDirectoryName(location);

            if (File.Exists(directoryName + FilePath))
            {
                using (StreamReader stReader = new StreamReader(directoryName + FilePath, Encoding.GetEncoding("UTF-8")))
                {
                    string line;
                    if (SkipFirstLineDocument)
                    {
                        line = stReader.ReadLine();
                    }

                    line = stReader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            students.Add(new Student(
                                int.Parse(data[0]),
                                data[1],
                                data[2],
                                data[3],
                                (Genders)Enum.Parse(typeof(Genders), data[4], true),
                                (StudentTypes)Enum.Parse(typeof(StudentTypes), data[5], true),
                                int.Parse(data[6]),
                                int.Parse(data[7]),
                                int.Parse(data[8]),
                                float.Parse(data[9]),
                                float.Parse(data[10]),
                                float.Parse(data[11])
                                ));
                        }

                        catch (SystemException se)
                        {
                            if (se is FormatException || se is ArgumentNullException || se is IndexOutOfRangeException)
                            {
                                Console.WriteLine("Incorrect file data.");
                                return;
                            }

                            throw;
                        }


                        line = stReader.ReadLine();
                    }
                }

                var onlineStudentsChart = from s in students
                                          where s.StudentType == StudentTypes.Online
                                          orderby s.Result descending
                                          select s;

                string[] headerItems = new string[] 
            { 
                "ID", 
                "First name", 
                "Last Name", 
                "Email", 
                "Gender", 
                "Student type", 
                "Exam result",
                "Homework sent", 
                "Homework evaluated",
                "Teamwork", 
                "Attendances", 
                "Bonus", 
                "Result"
            };

               var excel =  new ExcelGenerator(
               directoryName + "\\students.xlsx",
                "Online students",
                headerItems,
                onlineStudentsChart.ToList());
                excel.Generate();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("The file is not foud -" + (directoryName + FilePath));
            }

        }
    }
}
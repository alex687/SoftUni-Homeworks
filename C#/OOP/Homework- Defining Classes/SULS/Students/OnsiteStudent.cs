namespace SULS.Students
{
    class OnsiteStudent : CurrentStudent
    {
        public int NumberVisits { get; set; }

        public OnsiteStudent(string fName, string lName, string number, double avgGrade, string curCourse, int numVisits, int age = 0)
            : base(fName, lName, number, avgGrade, curCourse, age)
        {
            this.NumberVisits = numVisits;
        }
    }
}

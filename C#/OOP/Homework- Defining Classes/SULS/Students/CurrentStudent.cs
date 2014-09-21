namespace SULS.Students
{
    abstract class CurrentStudent : Student
    {
        public string CurrentCourse { get; set; }

        public CurrentStudent(string fName, string lName, string number, double avgGrade, string curCourse, int age = 0)
            :base(fName,lName,avgGrade,number,age)
        {
            this.CurrentCourse = curCourse;
        }
    }
}

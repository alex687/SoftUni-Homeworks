namespace SULS.Students
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string fName, string lName, string number, double avgGrade, int age = 0)
            : base(fName, lName, avgGrade, number, age)
        {
        }
    }
}

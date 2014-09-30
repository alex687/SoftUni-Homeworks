namespace LINQtoExcel
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string email;

        public Student(int id, string firstName, string lastName, string email, Genders gender, StudentTypes studentType,
                       int examResult, int homeworksSent, int homeworksEvaluated, float teamworkScore, float attendancesCount, float bonus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.StudentType = studentType;
            this.ExamResult = examResult;
            this.HomeworkSent = homeworksSent;
            this.HomeworkEvaluated = homeworksEvaluated;
            this.TeamworkScore = teamworkScore;
            this.Attendances = attendancesCount;
            this.Bonus = bonus;
            this.Result = this.CalculateResult();
        }

        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName", "FirstName can not be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "LastName can not be null or empty!");
                }

                this.lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email", "Email can not be null or empty!");
                }

                this.email = value;
            }
        }

        public Genders Gender { get; set; }

        public StudentTypes StudentType { get; set; }

        public int ExamResult { get; set; }

        public int HomeworkSent { get; set; }

        public int HomeworkEvaluated { get; set; }

        public float TeamworkScore { get; set; }

        public float Attendances { get; set; }

        public float Bonus { get; set; }

        public float Result { get; protected set; }

        private float CalculateResult()
        {
            return (this.ExamResult + this.HomeworkEvaluated + this.HomeworkSent + this.TeamworkScore + this.Attendances) / 5;
        }
    }
}

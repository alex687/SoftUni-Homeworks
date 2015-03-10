namespace StudentSystem.Model
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string ContentType { get; set; }

        public DateTime DateTime { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}

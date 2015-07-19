namespace GenerateRandomMatches
{
    using System;

    public class GenerateConfig
    {
        public GenerateConfig()
        {
            this.GenerateCount = 10;
            this.MaxGoals = 5;
            this.StartDate = new DateTime(2000, 1, 1);
            this.EndDate = new DateTime(2015, 12, 31);
        }

        public int GenerateCount { get; set; }

        public int MaxGoals { get; set; }

        public string League { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
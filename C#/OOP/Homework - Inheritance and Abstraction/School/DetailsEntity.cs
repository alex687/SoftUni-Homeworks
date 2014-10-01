namespace School
{
    using System;

    public class DetailsEntity
    {
        private string details;

        public string Details
        {
            get { return this.details; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Empty details");
                }

                this.details = value;
            }
        }

    }
}

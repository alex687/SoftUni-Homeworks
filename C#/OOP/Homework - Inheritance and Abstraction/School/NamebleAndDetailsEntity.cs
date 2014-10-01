namespace School
{
    using System;

    public class NamebleAndDetailsEntity : DetailsEntity
    {
        private string name;

        public NamebleAndDetailsEntity(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Empty name");
                }

                this.name = value;
            }
        }
    }
}

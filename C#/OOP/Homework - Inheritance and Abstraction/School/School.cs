namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private ICollection<Class> classes;

        public School(IList<Class> classes)
        {
            this.Classes = classes;
        }

        public ICollection<Class> Classes
        {
            get
            {
                return this.classes;    
            }

            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("Classes cannot be null or 0");
                }

                this.classes = value;
            }
        }
    }
}

using System;

namespace IntervalTree
{
    public class Interval<T, D> : IComparable<Interval<T, D>> where D : IComparable<D>
    {

        private D start;
        private D end;
        private T data;

        public Interval(D start, D end, T data)
        {
            this.start = start;
            this.end = end;
            this.data = data;
        }

        public D Start
        {
            get { return start; }
            set { start = value; }
        }

        public D End
        {
            get { return end; }
            set { end = value; }
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public bool Contains(D time, ContainConstrains constraint)
        {
            bool isContained;

            switch (constraint)
            {
                case ContainConstrains.None:
                    isContained = Contains(time);
                    break;
                case ContainConstrains.IncludeStart:
                    isContained = ContainsWithStart(time);
                    break;
                case ContainConstrains.IncludeEnd:
                    isContained = ContainsWithEnd(time);
                    break;
                case ContainConstrains.IncludeStartAndEnd:
                    isContained = ContainsWithStartEnd(time);
                    break;
                default:
                    throw new ArgumentException("Ivnalid constraint " + constraint);
            }

            return isContained;
        }


        public bool Contains(D time)
        {
            //return time < end && time > start;
            return time.CompareTo(end) < 0 && time.CompareTo(start) > 0;
        }


        public bool ContainsWithStart(D time)
        {
            return time.CompareTo(end) < 0 && time.CompareTo(start) >= 0;
        }


        public bool ContainsWithEnd(D time)
        {
            return time.CompareTo(end) <= 0 && time.CompareTo(start) > 0;
        }


        public bool ContainsWithStartEnd(D time)
        {
            return time.CompareTo(end) <= 0 && time.CompareTo(start) >= 0;
        }


        public bool Intersects(Interval<T, D> other)
        {
            //return other.End > start && other.Start < end;
            return other.End.CompareTo(start) > 0 && other.Start.CompareTo(end) < 0;
        }



        public int CompareTo(Interval<T, D> other)
        {
            if (start.CompareTo(other.Start) < 0)
                return -1;
            else if (start.CompareTo(other.Start) > 0)
                return 1;
            else if (end.CompareTo(other.End) < 0)
                return -1;
            else if (end.CompareTo(other.End) > 0)
                return 1;
            else
                return 0;
            //if (start < other.Start)
            //  return -1;
            //else if (start > other.Start)
            //  return 1;
            //else if (end < other.End)
            //  return -1;
            //else if (end > other.End)
            //  return 1;
            //else
            //  return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", start, end);
        }
    }

    public enum ContainConstrains
    {
        None,
        IncludeStart,
        IncludeEnd,
        IncludeStartAndEnd
    }
}

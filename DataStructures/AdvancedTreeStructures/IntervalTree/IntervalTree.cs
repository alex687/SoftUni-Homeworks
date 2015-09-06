using System;
using System.Collections.Generic;
using System.Text;

namespace IntervalTree
{
    using Wintellect.PowerCollections;

    public class IntervalTree<T, D> where D : struct, IComparable<D>
    {

        private IntervalNode<T, D> head;
        private List<Interval<T, D>> intervalList;
        private bool inSync;
        private int size;


        public IntervalTree()
        {
            this.head = new IntervalNode<T, D>();
            this.intervalList = new List<Interval<T, D>>();
            this.inSync = true;
            this.size = 0;
        }

        public IntervalTree(List<Interval<T, D>> intervalList)
        {
            this.head = new IntervalNode<T, D>(intervalList);
            this.intervalList = new List<Interval<T, D>>();
            this.intervalList.AddRange(intervalList);
            this.inSync = true;
            this.size = intervalList.Count;
        }


        public List<T> Get(D time)
        {
            return Get(time, StubMode.Contains);
        }

        public List<T> Get(D time, StubMode mode)
        {
            List<Interval<T, D>> intervals = GetIntervals(time, mode);
            List<T> result = new List<T>();
            foreach (Interval<T, D> interval in intervals)
                result.Add(interval.Data);
            return result;
        }


        public List<Interval<T, D>> GetIntervals(D time)
        {
            return GetIntervals(time, StubMode.Contains);
        }

        public List<Interval<T, D>> GetIntervals(D time, StubMode mode)
        {
            Build();

            List<Interval<T, D>> stubedIntervals;

            switch (mode)
            {
                case StubMode.Contains:
                    stubedIntervals = head.Stab(time, ContainConstrains.None);
                    break;
                case StubMode.ContainsStart:
                    stubedIntervals = head.Stab(time, ContainConstrains.IncludeStart);
                    break;
                case StubMode.ContainsStartThenEnd:
                    stubedIntervals = head.Stab(time, ContainConstrains.IncludeStart);
                    if (stubedIntervals.Count == 0)
                    {
                        stubedIntervals = head.Stab(time, ContainConstrains.IncludeEnd);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid StubMode " + mode, "mode");
            }

            return stubedIntervals;
        }

        public List<T> Get(D start, D end)
        {
            List<Interval<T, D>> intervals = GetIntervals(start, end);
            List<T> result = new List<T>();
            foreach (Interval<T, D> interval in intervals)
                result.Add(interval.Data);
            return result;
        }

        public List<Interval<T, D>> GetIntervals(D start, D end)
        {
            Build();
            return head.Query(new Interval<T, D>(start, end, default(T)));
        }

        public void AddInterval(Interval<T, D> interval)
        {
            intervalList.Add(interval);
            inSync = false;
        }

        public void AddInterval(D begin, D end, T data)
        {
            intervalList.Add(new Interval<T, D>(begin, end, data));
            inSync = false;
        }


        public bool IsInSync()
        {
            return inSync;
        }


        public void Build()
        {
            if (!inSync)
            {
                head = new IntervalNode<T, D>(intervalList);
                inSync = true;
                size = intervalList.Count;
            }
        }


        public int CurrentSize
        {
            get
            {
                return size;
            }
        }


        public int ListSize
        {
            get
            {
                return intervalList.Count;
            }
        }

        public IEnumerable<ICollection<Interval<T, D>>> GetIntersections()
        {
            Build();

            Queue<IntervalNode<T, D>> toVisit = new Queue<IntervalNode<T, D>>();
            toVisit.Enqueue(head);

            do
            {
                var node = toVisit.Dequeue();
                foreach (var intersection in node.Intersections)
                {
                    yield return intersection;
                }

                if (node.Left != null) toVisit.Enqueue(node.Left);
                if (node.Right != null) toVisit.Enqueue(node.Right);

            } while (toVisit.Count > 0);
        }

        public IList<Interval<T, D>> Intervals
        {
            get
            {
                return Algorithms.ReadOnly(intervalList);
            }
        }

        public override String ToString()
        {
            return NodeString(head, 0);
        }

        private String NodeString(IntervalNode<T, D> node, int level)
        {
            if (node == null)
                return "";

            var sb = new StringBuilder();
            for (int i = 0; i < level; i++)
                sb.Append("\t");
            sb.Append(node + "\n");
            sb.Append(NodeString(node.Left, level + 1));
            sb.Append(NodeString(node.Right, level + 1));
            return sb.ToString();
        }
    }

    public enum StubMode
    {
        Contains,
        ContainsStart,
        ContainsStartThenEnd
    }
}

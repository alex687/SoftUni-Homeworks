namespace String_Disperser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
     
    class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<StringDisperser>
    {
        private List<char> chars;

        private StringDisperser()
        {
            this.chars = new List<char>();
        }

        public StringDisperser(params string[] param)
            : this()
        {
            foreach (var str in param)
            {
                chars.AddRange(str.ToCharArray());
            }
        }

        private StringDisperser(char[] charArray)
            : this()
        {
            this.chars.AddRange(charArray);
        }

        public char[] ToArray()
        {
            return this.chars.ToArray();
        }

        public static bool operator ==(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return firstDisperser.Equals(secondDisperser);
        }

        public static bool operator !=(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return !firstDisperser.Equals(secondDisperser);
        }

        public override bool Equals(object obj)
        {
            if (obj is StringDisperser)
            {
                var otherDisperser = obj as StringDisperser;
                return this.ToString().Equals(otherDisperser.ToString());
            }

            return false;
        }

        public override string ToString()
        {
            return new String(chars.ToArray());
        }

        public override int GetHashCode()
        {
            return this.chars.GetHashCode() ^ this.ToString().GetHashCode();
        }

        public object Clone()
        {
            var dispenser = new StringDisperser(this.chars.ToArray());

            return dispenser;
        }

        public int CompareTo(StringDisperser other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public IEnumerator<StringDisperser> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

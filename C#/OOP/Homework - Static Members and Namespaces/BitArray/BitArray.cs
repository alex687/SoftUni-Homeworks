namespace BitArray
{
    using System;
    using System.Numerics;

    public class BitArray
    {
        private uint[] values;
        private int size;
      
        public BitArray(int size)
        {
            this.size = size;
            int numberIntegers = (int)Math.Ceiling((double)size / 32);
            this.values = new uint[numberIntegers];
        }

        public int Length
        {
            get
            {
                return this.size;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= (this.size - 1))
                {
                    uint value = this.values[index / 32];
                   
                    // Check the bit at position index
                    if ((value & (1 << (index % 32))) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Index {0} is invalid!", index));
                }
            }

            set
            {
                if (index < 0 || index > this.size - 1)
                {
                    throw new IndexOutOfRangeException(
                         string.Format("Index {0} is invalid!", index));
                }

                if (value < 0 || value > 1)
                {
                    throw new ArgumentException(
                        string.Format("Value {0} is invalid!", value));
                }

                uint aValue = this.values[index / 32];

                // Clear the bit at position index
                aValue &= ~((uint)(1 << (index % 32)));

                // Set the bit at position index to value
                aValue |= (uint)(value << (index % 32));

                this.values[index / 32] = aValue;
            }
        }

        public override string ToString()
        {
            return this.ArrayToBigNumber().ToString();
        }

        private BigInteger ArrayToBigNumber()
        {
            BigInteger num = BigInteger.Zero;
            BigInteger exp2 = BigInteger.One;
            for (int pos = 0; pos < this.size; pos++)
            {
                exp2 *= 2;
                if (this[pos] == 1)
                {
                    num += exp2 / 2;
                }
            }

            return num;
        }
    }
}

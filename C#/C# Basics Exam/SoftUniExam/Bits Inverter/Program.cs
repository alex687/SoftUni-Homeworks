using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bits_Inverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            string number;
            StringBuilder bits = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                number = Convert.ToString(int.Parse(Console.ReadLine()), 2);
                number = number.PadLeft(8, '0');
                bits.Append(number);
            }

            int start = 0;
            int count = 0;
            char[] setbits = bits.ToString().ToCharArray();
     //      Console.WriteLine(bits.ToString());
      //     Console.WriteLine(setbits.Length);
               while (setbits.Length  > start)
               {
                   if (setbits[start] == '1')
                   {
                       setbits[start] = '0';
                   }
                   else if (setbits[start] == '0')
                   {
                       setbits[start] = '1';
                   }
                   count++;
                   start = (step * count);
                   //   Console.WriteLine(start);
               }
           

            StringBuilder allnumbers = new StringBuilder();
            for (int i = 0; i < setbits.Length; i++)
            {
                allnumbers.Append(setbits[i]);
            }
            string allNumbers = allnumbers.ToString();
       //     Console.WriteLine(allNumbers);
            for (int i = 0; i < allNumbers.Length; i=i+8)
            {
                
                    Console.WriteLine(Convert.ToInt32(allNumbers.Substring(i, 8),2));
                   
                
            }
        }
    }
}

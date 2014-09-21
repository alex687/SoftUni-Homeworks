using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineDigitMagicNumbers
{
    class Program
    {
        public static int convertToInt(int a, int b, int c){
                                StringBuilder abcBuilder = new StringBuilder();
                                                    abcBuilder.Append(a);
                                                    abcBuilder.Append(b);
                                                    abcBuilder.Append(c);
                                                    return int.Parse(abcBuilder.ToString());
        }
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int diff = int.Parse(Console.ReadLine());
        bool hasNum = false;
     /*/   if (sum > 60 || sum < 9)
        {
            Console.WriteLine("No");
            return;
        }
        if (diff == 0)
        {
            Console.WriteLine("No");
        }*/
                for (int a = 1; a <=7; a++)
                {
                    for (int b = 1; b <=7; b++)
                    {
                        for (int c = 1; c <= 7; c++)
                        {
                           for (int d = 1; d <= 7; d++)
			                {
                                for (int e = 1; e <=7; e++)
                                {
                                    for (int f = 1; f <=7 ; f++)
                                    {
                                        for (int g = 1; g <= 7; g++)
                                        {
                                            for (int h = 1; h <=7; h++)
                                            {
                                                for (int i = 1; i <=7; i++)
                                                {
                      
                                                    int abc = a * 100 + b * 10 + c;
                                                    int def = d * 100 + e * 10 + f;
                                                    int ghi = g * 100 + h * 10 + i;
                                                    if (ghi - def == diff && def - abc == diff)
                                                    {
                                                      //  if (a + b + c + d + e + f + g + h + i == sum && abc < def && def < ghi)
                                                        //{
                                                            Console.Write(a + string.Empty+ b + c + d + e + f + g + h + i);
                                                            Console.WriteLine();
                                                            hasNum = true;
                                                        //}
                                                    }
                                                }
                                            }   
                                        }
                                    }
                                }
			                } 
                        }  
                    }
                }

                if (!hasNum)
                {
                    Console.WriteLine("No");
                }
            }


    }
    }


    


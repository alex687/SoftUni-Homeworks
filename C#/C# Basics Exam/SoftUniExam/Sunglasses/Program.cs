using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {

        // 1 - * 0-  / 3 - | 4- ' '

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] output = new int[n,(n*4)+n];
            // Up
            for (int i = 0; i < 2*n; i++)
            {
                output[0, i] = 1;
            }


            for (int i = 2 * n + n; i < (n * 4) + n; i++)
            {
                output[0, i] = 1;
            }

            //Down
            for (int i = 0; i < 2*n; i++)
            {
                output[n-1, i] = 1;
            }


            for (int i = 2 * n + n; i < (n * 4) + n; i++)
            {
                output[n-1, i] = 1;
            }
            
//Left right up
            for (int i = 1; i < n; i++)
            {
                output[i, 0] = 1;
            }


            
            for (int i = 1; i < n; i++)
            {
                output[i, (n*2)-1] = 1;
            }


            //Left right down
            for (int i = 1; i < n; i++)
            {
                output[i, n*2+n] = 1;
            }



            for (int i = 1; i < n; i++)
            {
                output[i, (n * 4+n) - 1] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = n * 2 ; j < n * 2 + n; j++)
                {
                    output[i, j] = 4;
                }
            }

            int middlee = (n / 2) ;
            //Console.WriteLine(middlee);
            for (int j = n * 2; j < n * 2 + n; j++)
            {
                output[middlee, j] =3 ;  
            }

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n*4+n; j++)
                {
                    if (output[i, j] == 1)
                    {
                        Console.Write('*'); ;
                    }
                    if (output[i, j] == 0)
                    {
                        Console.Write('/'); ;
                    }
                    if (output[i, j] == 4)
                    {
                        Console.Write(' ');
                    }
                    if (output[i, j] == 3)
                    {
                        Console.Write('|');
                    } 
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = getRandomInts(1000000);
            var sw = new Stopwatch();
            sw.Start();
            FindDoubles(list);
            sw.Stop();
            Console.WriteLine("Fine appproach: " + sw.Elapsed);
            sw.Restart();
            FindDoublesBruteForce(list);
            sw.Stop();
            Console.WriteLine("Brute force appproach: " + sw.Elapsed);
            Console.ReadKey();
        }

        public static void FindDoublesBruteForce(int [] list)
        {
            for (int i = 0; i < list.Length-1; i++)
            {
                for(int j = 0; j < list.Length-1; j++)
                {
                    if (i == j) continue;
                    if (list[i] == 2 * list[j]) ;//Console.WriteLine("Nasli smo duple : " + list[i] + " i " + list[j]);
                }
            }
        }

        public static void FindDoubles(int[] list)
        {
            Array.Sort(list);
            Queue<int> q = new Queue<int>();
            int j = list.Length - 1;
            while (j!=1)//dok nismo dosli do zadnjega
            {
                if (list[j] > 2 * list[j - 1])                
                    q.Clear();//oni na redu su svi veci od j-tog elementa dakle i od dvostrukog j-1 elementa
               
                else if (list[j] < 2 * list[j - 1])//j-ti element nije j-1-om elementu dupli ali mozda jedan na stogu jest
                {
                    while (q.Count > 0)
                    {
                        if (q.Peek() > 2 * list[j - 1]) q.Dequeue();
                        else if (q.Count > 0 && q.Peek() == 2 * list[j - 1])                        
                            Console.WriteLine("Pronasli smo duple!" + list[j - 1] + " i " + q.Dequeue());
                        else break;
                    }
                    q.Enqueue(list[j]);
                }
                else                
                    Console.WriteLine("van queueue Pronasli smo duple!" + list[j-1] + " i " + list[j]);
                
                j--;
            }
        }

        public static int[] getRandomInts(int howMuch)
        {
            int[] numbers = new int[howMuch];
            var rand = new Random();
            for (int i = 0; i < howMuch; i++)
            {

                numbers[i] = rand.Next(0, 10000);

            }
            return numbers;
        }
    }
}

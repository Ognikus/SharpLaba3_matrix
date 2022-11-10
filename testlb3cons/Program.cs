using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Int64 M = r.Next() % 20 + 1;
            Int64 N = r.Next() % 20 + 1;
            Int64[][] matr = new Int64[M][];
            for (Int64 i = 0; i < M; i++)
                matr[i] = new Int64[N];
            for (Int64 i = 0; i < M; i++)
                for (Int64 j = 0; j < N; j++)
                    matr[i][j] = r.Next() % 100;

            Console.WriteLine(f(matr));
            Console.ReadLine();
        }
        static String f(Int64[][] m)
        {
            String res = "";
            foreach (Int64[] l in m)
            {
                Int64 accumulator = 0;
                Boolean first = true;
                foreach (Int64 i in l)
                {
                    accumulator += i;
                    res += ((first ? "" : "+") + i.ToString());
                    if (first) first = false;
                }
                res += ("=" + accumulator + "\n");
            }
            return res;
        }
    }
}
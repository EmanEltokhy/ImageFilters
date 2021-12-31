using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImageFilters
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //byte[,] w = { { 1, 2, 3 }, { 4, 5, 6, }, { 7, 8, 9 } };
            //int[] a = Neighbours(w, 3, 0, 0);
            //for(int i = 0; i < a.Length; i++)
            //{
            //    Console.WriteLine(a[i]);
            //}
        }
        //public static int[] Neighbours(byte[,] ImageMatrix, int N, int i, int j)
        //{
        //    byte[,] Matrix = new byte[ImageMatrix.GetLength(0), ImageMatrix.GetLength(1)];
        //    Matrix = ImageMatrix;
        //    int[] array = new int[N * N];
        //    int index = 0;
        //    int ii = i - (N / 2);
        //    int jj = j - (N / 2);
        //    int CI = i + (N / 2);
        //    int CJ = j + (N / 2);
        //    if (ii < 0)
        //    {
        //        ii = 0;
        //    }
        //    if (jj < 0)
        //    {
        //        jj = 0;
        //    }
        //    if (CI >= ImageMatrix.GetLength(0))
        //        CI = ImageMatrix.GetLength(0) - 1;
        //    if (CJ >= ImageMatrix.GetLength(1))
        //        CJ = ImageMatrix.GetLength(1) - 1;
        //    for (int f = ii; f <= CI; f++)
        //    {
        //        for (int s = jj; s <= CJ; s++)
        //        {
        //            if (f == i && s == j)
        //                continue;
        //            else
        //            {
        //                int a = Matrix[f, s];
        //                array[index] = a;
        //            }
        //            index++;
        //        }

        //    }
            
        //    Console.WriteLine("before");
        //    for (int z = 0; z < array.Length; z++)
        //    {
        //        Console.WriteLine(array[z]);
        //    }
        //    //array[(N * N) - 1] = index++;
        //    int q = index;
        //    Console.WriteLine("index  "+ q);
        //    int[] x = new int[index];
        //    for (int d = 0; d < q; d++)
        //        x[d] = array[d];
        //    array = x;
        //    return array;
        //}
    }
}

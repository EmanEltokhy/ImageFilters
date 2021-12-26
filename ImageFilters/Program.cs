using System;
using System.Collections.Generic;
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

            //int[] array = { 5, 9, 2, 1, 23, 4 };


            //byte[,] d = { { 3, 2, 1 }, { 6, 5, 4 }, { 7, 8, 9 } };
            //Alpha_trim_filter t = new Alpha_trim_filter();
            //for (int i = 0; i < d.GetLength(0); i++)
            //{
            //    for (int j = 0; j < d.GetLength(1); j++)
            //    {
            //        array = t.Neighbours(d, 3, i, j);
            //        array = t.countSort(array, 3);
            //        if (array.Length - 4 < 0)
            //            continue;
            //        else
            //        {
            //            int index = 0;
            //            int sum = 0;
            //            int[] w = new int[array.Length - 4];
            //            for (int l = 2; l < array.Length - 2; l++)
            //            {
            //                w[index] = array[l];
            //                index++;
            //            }
            //            for (int q = 0; q < w.Length; q++)
            //            {
            //                sum += w[q];
            //            }
            //            d[i, j] = (byte)(sum / w.Length);

                        //for (int k = 0; k < w.Length; k++)
                        //    Console.Write(w[k]);
                        //Console.WriteLine();
             //       }
             //   }
            //}
            //for (int e = 0; e < 3; e++)
            //{
            //    for (int r = 0; r < d.GetLength(1); r++)
            //    {
            //        Console.Write(d[e, r]);
            //    }
            //    Console.WriteLine();
        }
        //array = t.countSort(array);
        //for (int k = 0; k < array.Length; k++)
        //    Console.WriteLine(array[k]);
    }
}

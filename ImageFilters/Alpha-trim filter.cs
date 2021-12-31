using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    internal class Alpha_trim_filter
    {
        public byte[,] NewImage(byte[,] ImageMatrix, int T, int N)
        {
            byte[,] Matrix =  ImageMatrix;
            byte[,] newMatrix = new byte[Matrix.GetLength(0),Matrix.GetLength(1)];

            int[] array = { };
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    array = Neighbours(Matrix, N, i, j);  
                    array = countSort(array, N);

                    if (array.Length - T * 2 <= 0)
                    {
                        newMatrix[i,j] = Matrix[i, j];
                        continue;
                    }
                    else
                    {
                        int index = 0;
                        int[] w = new int[array.Length - T * 2];
                        for (int l = T; l < array.Length - T; l++)
                        {
                            w[index] = array[l];
                            index++;
                        }
                        int sum = 0;
                        for (int q = 0; q < w.Length; q++)
                        {
                            sum += w[q];
                        }
                        newMatrix[i, j] = (byte)(sum / w.Length);
                    }
                }
            }
            return newMatrix;
        }
        public int[] Neighbours(byte[,] ImageMatrix, int N, int i, int j)
        {
            byte[,] Matrix = new byte[ImageMatrix.GetLength(0), ImageMatrix.GetLength(1)];
            Matrix = ImageMatrix;
            int[] array = new int[N * N];
            int index = 0;
            int ii = i - (N / 2);
            int jj = j - (N / 2);
            int CI = i + (N / 2);
            int CJ = j + (N / 2);
            if (ii < 0)
            {
                ii = 0;
            }
            if (jj < 0)
            {
                jj = 0;
            }
            if (CI >= ImageMatrix.GetLength(0))
                CI = ImageMatrix.GetLength(0) - 1;
            if (CJ >= ImageMatrix.GetLength(1))
                CJ = ImageMatrix.GetLength(1) - 1;
            for (int f = ii; f <= CI; f++)
            {
                for (int s = jj; s <= CJ; s++)
                {
                    if (f == i && s == j)
                        continue;
                    else
                    {
                        int a = Matrix[f, s];
                        array[index] = a;
                    }
                    index++;
                }

            }
            //array[(N * N) - 1] = index++;
            int q = index;
            int[] x = new int[index];
            for (int d = 0; d < q; d++)
                x[d] = array[d];
            array = x;
            return array;
        }

        public int[] countSort(int[] array, int N)
        {
            int size = array.Length;
            int max = 0;
            int[] a = new int[size];
            //find largest element in the Array
            for (int i = 0; i < size; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            //Create a freq array to store number of occurrences of 
            //each unique elements in the given array 
            int[] freq = new int[max + 1];
            for (int i = 0; i < max + 1; i++)
            {
                freq[i] = 0;
            }
            for (int i = 0; i < size; i++)
            {
                freq[array[i]]++;
            }

            //sort the given array using freq array
            for (int i = 0, j = 0; i <= max; i++)
            {
                while (freq[i] > 0)
                {
                    array[j] = i;
                    j++;
                    freq[i]--;
                }
            }
            // Copy the sorted elements into original array
            for (int i = 0; i < size; i++)
            {
                a[i] = array[i];
            }

            return a;

        }
        //public int[] Neighbours(byte[,] ImageMatrix, int N, int i, int j)
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
        //        CI = ImageMatrix.GetLength(0)-1;
        //    if (CJ >= ImageMatrix.GetLength(1))
        //        CJ = ImageMatrix.GetLength(1)-1;
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
        //    array[(N * N) - 1] = index++;
        //    return array;
        //}

        //public int[] countSort(int[] array, int N)
        //{
        //    int size = array[(N * N) - 1];
        //    int max = 0;
        //    int[] a = new int[size];
        //    //find largest element in the Array
        //    for (int i = 0; i < size; i++)
        //    {
        //        if (max < array[i])
        //        {
        //            max = array[i];
        //        }
        //    }

        //    //Create a freq array to store number of occurrences of 
        //    //each unique elements in the given array 
        //    int[] freq = new int[max + 1];
        //    for (int i = 0; i < max + 1; i++)
        //    {
        //        freq[i] = 0;
        //    }
        //    for (int i = 0; i < size; i++)
        //    {
        //        freq[array[i]]++;
        //    }

        //    //sort the given array using freq array
        //    for (int i = 0, j = 0; i <= max; i++)
        //    {
        //        while (freq[i] > 0)
        //        {
        //            array[j] = i;
        //            j++;
        //            freq[i]--;
        //        }
        //    }
        //    // Copy the sorted elements into original array
        //    for (int i = 0; i < array[(N*N)-1]; i++)
        //    {
        //        a[i] = array[i];
        //    }

        //    return a;
        //}
    }
}

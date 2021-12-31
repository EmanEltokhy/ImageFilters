using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    internal class adaptive_median_filter
    {

        public byte[,] NewImage(byte[,] ImageMatrix, int N, int Sort_Selection)
        {
            byte[,] Matrix = ImageMatrix;
            byte[,] newMatrix = new byte[Matrix.GetLength(0), Matrix.GetLength(1)];

            
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = Filter(ImageMatrix, i, j, N, Sort_Selection);
                }
            }
            return newMatrix;
        }

        public byte Filter(byte[,] ImageMatrix, int i, int j, int N, int Selection, int Size = 3)
        {
            byte[,] Matrix = ImageMatrix;
            int X = Matrix[i, j];
            int[] array = Neighbours(Matrix, Size, i, j);
            if (Selection == 0)
                array = quickSort(array, array.Length-1,0);
            else if (Selection == 1)
                array = countSort(array, Size);
            int max = array.Max();
            int min = array.Min();
            int med = array[array.Length / 2];
            int A1 = med - min;
            int A2 = max - med;
            if (A1 > 0 && A2 > 0)
            {
                int B1 = X - min;
                int B2 = max - X;
                if (B1 > 0 && B2 > 0)
                {
                    return Matrix[i, j];
                }
                else
                {
                    return (byte)med;
                }
            }
            else
            {
                Size += 2;
                if (Size <= N)
                    return Filter(ImageMatrix, i,j,N, Selection, Size);
                else
                    return (byte)med;
            }
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
            int[] Accurate_Array = new int[index];
            for (int d = 0; d < index; d++)
                Accurate_Array[d] = array[d];
            return Accurate_Array;
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
        public int[] quickSort(int[] a, int end, int start)
        {
            if (start <= end)
            {
                int pivot = a[end];
                int index = start;
                for (int i = start; i < end; i++)
                {
                    if (a[i] < pivot)
                    {
                        Swap(ref a[index], ref a[i]);
                        index++;
                    }
                }
                Swap(ref a[index], ref a[end]);
                quickSort(a, index - 1, start);
                quickSort(a, end, index + 1);
            }
            return a;
        }

        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}

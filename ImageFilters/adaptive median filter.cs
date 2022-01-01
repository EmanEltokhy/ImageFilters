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
            byte[,] Matrix = ImageMatrix;       //O(1)
            byte[,] newMatrix = new byte[Matrix.GetLength(0), Matrix.GetLength(1)];     //O(1)


            for (int i = 0; i < Matrix.GetLength(0); i++)      //no. of iter * order of body = O(1) * O(N^2) = O(N^2)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)  //no. of iter * order of body = O(1) * O(N^2) = O(N^2)
                {
                    newMatrix[i, j] = Filter(ImageMatrix, i, j, N, Sort_Selection);  //O(N^2)
                }
            }
            return newMatrix;       //O(1)
        }

        public byte Filter(byte[,] ImageMatrix, int i, int j, int N, int Selection, int Size = 3)
        {
            byte[,] Matrix = ImageMatrix;   //O(1)
            int X = Matrix[i, j];           //O(1)
            int[] array = Neighbours(Matrix, Size, i, j);   //O(N^2)
            if (Selection == 0)             //If by the order of its body 
                array = quickSort(array, array.Length-1,0); //O(N^2)
            else if (Selection == 1)        //If by the order of its body 
                array = countSort(array, Size);     //O(N)
            int max = array.Max();                  //O(1)
            int min = array.Min();                  //O(1)
            int med = array[array.Length / 2];      //O(1)
            int A1 = med - min;     //O(1)
            int A2 = max - med;     //O(1)
            if (A1 > 0 && A2 > 0) 
            {
                int B1 = X - min;   //O(1)
                int B2 = max - X;   //O(1)
                if (B1 > 0 && B2 > 0)       //O(1)
                {
                    return Matrix[i, j];    //O(1)
                }
                else
                {
                    return (byte)med;       //O(1)
                }
            }
            else
            {
                Size += 2;       //O(1)
                if (Size <= N)
                    return Filter(ImageMatrix, i,j,N, Selection, Size);  //O(N^2)   
                else
                    return (byte)med; // O(1)
            }
        }
        public int[] Neighbours(byte[,] ImageMatrix, int N, int i, int j)
        {
            byte[,] Matrix = new byte[ImageMatrix.GetLength(0), ImageMatrix.GetLength(1)];  //O(1)
            Matrix = ImageMatrix;            //O(1)
            int[] array = new int[N * N];   //O(1)
            int index = 0;                  //O(1)
            int ii = i - (N / 2);   //O(1)
            int jj = j - (N / 2);   //O(1)
            int CI = i + (N / 2);   //O(1)
            int CJ = j + (N / 2);   //O(1)
            if (ii < 0) //O(1)
            {
                ii = 0; //O(1)
            }
            if (jj < 0) //O(1)
            {
                jj = 0; //O(1)
            }
            if (CI >= ImageMatrix.GetLength(0))     //O(1)
                CI = ImageMatrix.GetLength(0) - 1;  //O(1)
            if (CJ >= ImageMatrix.GetLength(1))     //O(1)
                CJ = ImageMatrix.GetLength(1) - 1;  //O(1)
            for (int f = ii; f <= CI; f++)          //no. of iter * order of body = CI * O(CJ) = O(CI * CJ)
            {
                for (int s = jj; s <= CJ; s++)      //no. of iter * order of body = CJ * O(1) = O(CJ)
                {
                    if (f == i && s == j)   //O(1)
                        continue;
                    else
                    {
                        int a = Matrix[f, s];   //O(1)
                        array[index] = a;       //O(1)
                    }
                    index++;                    //O(1)
                }

            }
            int[] Accurate_Array = new int[index]; //O(1)
            for (int d = 0; d < index; d++)// no. of iter * order of body = O(index)*O(1)
                Accurate_Array[d] = array[d];//O(1)
            return Accurate_Array; //O(1)
        }

        public int[] countSort(int[] array, int N)  //O(size + max)
                                                    //)
        {
            int size = array.Length;        //O(1)
            int max = 0;                    //O(1)
            int[] a = new int[size];        //O(1)
            //find largest element in the Array
            for (int i = 0; i < size; i++)  //no. of iter * order of body = O(max) * O(1) = O(size)
            {
                if (max < array[i])     //O(1)
                {
                    max = array[i];     //O(1)
                }
            }

            //Create a freq array to store number of occurrences of 
            //each unique elements in the given array 
            int[] freq = new int[max + 1];    //O(1)
            for (int i = 0; i < max + 1; i++) //no. of iter * order of body = O(max) * O(1) = O(size)
            {
                freq[i] = 0;                //O(1)
            }
            for (int i = 0; i < size; i++)  //no. of iter * order of body = O(size) * O(1) = O(size)
            {
                freq[array[i]]++;           //O(1)
            }

            //sort the given array using freq array
            for (int i = 0, j = 0; i <= max; i++)   //no. of iter * order of body = O(N) * O(max) = O(N^2)
            {
                while (freq[i] > 0)         //O(N)..
                {
                    array[j] = i;//O(1)
                    j++;        //O(1)
                    freq[i]--;  //O(1)
                }
            }
            // Copy the sorted elements into original array
            for (int i = 0; i < size; i++)      //no. of iter * order of body = O(size) * O(1) = O(size) 
            {
                a[i] = array[i];        //O(1)
            }

            return a;       //O(1)
            
        }
        public int[] quickSort(int[] a, int end, int start)
        {
            if (start <= end)   //O(N)                       //  T(n) = T(k) + T(n-k-1) + theta(n)  
            {
                int pivot = a[end]; //O(1)
                int index = start;  //O(1)
                for (int i = start; i < end; i++) //no. of iter * order of body = O(N) * O(1) = O(N)
                {
                    if (a[i] < pivot)   //O(1)
                    {
                        Swap(ref a[index], ref a[i]);   //O(1)
                        index++;        //O(1)
                    }
                }
                Swap(ref a[index], ref a[end]);     //O(1)
                quickSort(a, index - 1, start);     //O(N^2)
                quickSort(a, end, index + 1);       //O(N^2)
            }
            return a;           // O(1)
        }

        private void Swap(ref int x, ref int y) //O(1)
        {
            int temp = x;       //O(1)
            x = y;              //O(1)
            y = temp;           //O(1)
        }
    }
}

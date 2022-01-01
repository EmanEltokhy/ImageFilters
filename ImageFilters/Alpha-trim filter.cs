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
            int[] array = new int[N * N];           //O(1)           
            int index = 0;                          //O(1)
            int ii = i - (N / 2);                   //O(1)
            int jj = j - (N / 2);                   //O(1)
            int CI = i + (N / 2);                   //O(1)
            int CJ = j + (N / 2);                   //O(1)
            if (ii < 0)                             //O(1)
            {
                ii = 0;                             //O(1)
            }   
            if (jj < 0)                             //O(1)
            {
                jj = 0;                             //O(1)
            }
            if (CI >= ImageMatrix.GetLength(0))     //O(1)
                CI = ImageMatrix.GetLength(0) - 1;  //O(1)
            if (CJ >= ImageMatrix.GetLength(1))     //O(1)
                CJ = ImageMatrix.GetLength(1) - 1;  //O(1)
            for (int f = ii; f <= CI; f++)          //no. of iter * order of body = CI * O(CJ) = O(CI * CJ) 
            {
                for (int s = jj; s <= CJ; s++)      //no. of iter * order of body = CJ * O(1) = O(CJ) 
                {
                    if (f == i && s == j)           //O(1)
                        continue;
                    else
                    {
                        int a = ImageMatrix[f, s];  //O(1)
                        array[index] = a;           //O(1)
                    }
                    index++;                        //O(1)
                }

            }
            int q = index;
            int[] x = new int[index];
            for (int d = 0; d < q; d++)
                x[d] = array[d];
            array = x;
            return array;
        }

        public int[] countSort(int[] array, int N)  //O(size + max)
        {
            int size = array.Length;                //O(1)
            int max = 0;                            //O(1)
            int[] a = new int[size];                //O(1)
            //find largest element in the Array
            for (int i = 0; i < size; i++)          //no. of iter * order of body = size * O(1) = O(size) 
            {
                if (max < array[i])                 //O(1)
                {
                    max = array[i];                 //O(1)
                }
            }

            //Create a freq array to store number of occurrences of 
            //each unique elements in the given array 
            int[] freq = new int[max + 1];          //O(1)
            for (int i = 0; i < max + 1; i++)       //no. of iter * order of body = max * O(1) = O(max)
            {
                freq[i] = 0;                        //O(1)
            }
            for (int i = 0; i < size; i++)          //no. of iter * order of body = size * O(1) = O(size)
            {
                freq[array[i]]++;                   //O(1)
            }

            // Store the cummulative count of each array
            for (int i = 1; i <= max; i++)          //no. of iter * order of body = max * O(1) = O(max)
            {
                freq[i] += freq[i - 1];             //O(1)
            }

            // Find the index of each element of the original array in count array, and
            // place the elements in output array
            for (int i = size - 1; i >= 0; i--)     //no. of iter * order of body = size * O(1) = O(size)     
            {
                array[freq[array[i]] - 1] = freq[i];//O(1)
                freq[array[i]]--;                   //O(1)
            }
            ////sort the given array using freq array
            //for (int i = 0, j = 0; i <= max; i++)   //no. of iter * order of body = max * O(freq[i]) = O(max * freq[i])
            //{
            //    while (freq[i] > 0)                 //no. of iter * order of body =  freq[i] * O(1) = O(freq[i])
            //    {
            //        array[j] = i;                   //O(1)
            //        j++;                            //O(1)
            //        freq[i]--;                      //O(1)
            //    }
            //}
            // Copy the sorted elements into original array
            
            return array;                             //O(1)

        }
    }
}

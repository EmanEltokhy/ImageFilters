using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    internal class Alpha_trim_filter
    {
        public byte[,] NewImage(byte[,] ImageMatrix, int T, int N, int Sort_Selection)
        {
            byte[,] newMatrix = new byte[ImageMatrix.GetLength(0), ImageMatrix.GetLength(1)];

            for (int i = 0; i < ImageMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ImageMatrix.GetLength(1); j++)
                {
                    int[] array = Neighbours(ImageMatrix, N, i, j);
                    if (Sort_Selection == 0)
                        newMatrix[i, j] = Filter_With_CountSort(ImageMatrix, i, j, N, T, array);
                    else if (Sort_Selection == 1)
                        newMatrix[i, j] = Filter_WithoutSort(ImageMatrix, i, j, T, array);
                }
            }
            return newMatrix;
        }
        public byte Filter_With_CountSort(byte[,] ImageMatrix, int i, int j, int N, int T, int[] array)
        {
            countSort(array);
            if (array.Length - T * 2 <= 0)
            {
                return ImageMatrix[i, j];
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
                return (byte)(sum / w.Length);
            }
        }
        public byte Filter_WithoutSort(byte[,] ImageMatrix, int i, int j, int T, int[] array)
        {
            int Size_Array = array.Length;
            if (Size_Array - T * 2 <= 0)
            {
                return ImageMatrix[i, j];
            }
            else
            {
                int[] Smallest_T_Numbers = HeapSort(array, array.Length, T, 0);
                int[] Largest_T_Numbers = HeapSort(array, array.Length, T, 1);
                int Sum_T = 0, Sum_All = 0;
                int Size_Small = Smallest_T_Numbers.Length;
                int Size_Large = Largest_T_Numbers.Length;
                for (int small = 0; small < Size_Small; small++)
                    Sum_T += Smallest_T_Numbers[small];
                for (int large = 0; large < Size_Large; large++)
                    Sum_T += Largest_T_Numbers[large];
                for (int all_elements = 0; all_elements < Size_Array; all_elements++)
                    Sum_All += array[all_elements];
                return (byte)((Sum_All - Sum_T) / (Size_Array - (Size_Small + Size_Large)));
            }
        }
        public int[] Neighbours(byte[,] ImageMatrix, int N, int i, int j)
        {
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
                        int a = ImageMatrix[f, s]; 
                        array[index] = a;           
                    }
                    index++;                        
                }

            }
            int q = index;
            int[] x = new int[index];
            for (int d = 0; d < q; d++)
                x[d] = array[d];
            array = x;
            return array;
        }

        public int Left(int i)
        {
            return 2 * i + 1;
        }
        public int Right(int i)
        {
            return 2 * i + 2;
        }
        public void Max_Heap(int[] array, int Length, int i)
        {
            int left = Left(i);
            int right = Right(i);
            int Max = i;
            if (left < Length && array[left] > array[Max])
                Max = left;
            if (right < Length && array[right] > array[Max])
                Max = right;
            if (Max != i)
            {
                int temp = array[i];
                array[i] = array[Max];
                array[Max] = temp;
                Max_Heap(array, Length, Max);
            }
        }
        public void Min_Heap(int[] array, int Length, int i)
        {
            int left = Left(i);
            int right = Right(i);
            int Smallest = i;
            if (left < Length && array[left] < array[Smallest])
                Smallest = left;
            if (right < Length && array[right] < array[Smallest])
                Smallest = right;
            if (Smallest != i)
            {
                int temp = array[i];
                array[i] = array[Smallest];
                array[Smallest] = temp;
                Min_Heap(array, Length, Smallest);
            }
        }
        public void Build(int[] array, int Length, int selection)
        {
            for (int i = Length / 2 - 1; i >= 0; i--)
                if (selection == 0)
                    Min_Heap(array, Length, i);
                else if (selection == 1)
                    Max_Heap(array, Length, i);

        }
        public int[] HeapSort(int[] Array, int Length, int T, int selection)
        {
            int Size = Length;
            Build(Array, Length, selection);
            int[] a = new int[T];
            for (int i = Length - 1, j = 0; i >= Length - T; i--)
            {
                int Temp = Array[0];
                Array[0] = Array[i];
                a[j] = Temp;
                Array[i] = Temp;
                Size--;
                if (selection == 0)
                    Min_Heap(Array, Size, 0);
                else if (selection == 1)
                    Max_Heap(Array, Size, 0);
                j++;
            }
            return a;
        }

        public void countSort(int[] array)
        {

            int size = array.Length;
            int max = array[0];

            // Find the largest element of the array
            for (int i = 1; i < size; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            int[] output = new int[max + 1];
            int[] freq = new int[max + 1];

            // Initialize count array with all zeros.
            for (int i = 0; i <= max; ++i)
            {
                freq[i] = 0;
            }

            // Store the count of each element
            for (int i = 0; i < size; i++)
            {
                freq[array[i]]++;
            }

            // Store the cummulative count of each array
            for (int i = 1; i <= max; i++)
            {
                freq[i] += freq[i - 1];
            }

            // Find the index of each element of the original array in count array, and
            // place the elements in output array
            for (int i = size - 1; i >= 0; i--)
            {
                output[freq[array[i]] - 1] = array[i];
                freq[array[i]]--;
            }

            // Copy the sorted elements into original array
            for (int i = 0; i < size; i++)
            {
                array[i] = output[i];
            }
        }

    }
}

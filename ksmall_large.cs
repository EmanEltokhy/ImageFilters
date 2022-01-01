using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class GFG
    {
        public class MaxHeap
        {
            public int[] harr; // pointer to array of elements in
                               // heap
            public int capacity; // maximum possible size of max
                                 // heap
            public int heap_size; // Current number of elements in
                                  // max heap
            public int parent(int i)
            {
                return (i - 1) / 2;
            }
            public int left(int i)
            {
                return (2 * i + 1);
            }
            public int right(int i)
            {
                return (2 * i + 2);
            }
            public int getMax()
            {
                return harr[0];
            } // Returns maximum

            // to replace root with new node x and heapify() new
            // root
            public void replaceMax(int x)
            {
                this.harr[0] = x;
                maxHeapify(0);
            }
            public MaxHeap(int[] a, int size)
            {
                heap_size = size;
                harr = a; // store address of array
                int i = (heap_size - 1) / 2;
                while (i >= 0)
                {
                    maxHeapify(i);
                    i--;
                }
            }

            // Method to remove maximum element (or root) from
            // max heax
            public int extractMax()
            {
                if (heap_size == 0)
                    return int.MaxValue;

                // Store the maximum value.
                int root = harr[0];

                // If there are more than 1 items, move the last
                // item to root and call heapify.
                if (heap_size > 1)
                {
                    harr[0] = harr[heap_size - 1];
                    maxHeapify(0);
                }
                heap_size--;
                return root;
            }

            // A recursive method to heapify a subtree with root
            // at given index This method assumes that the
            // subtrees are already heapified
            public void maxHeapify(int i)
            {
                int l = left(i);
                int r = right(i);
                int largest = i;
                if (l < heap_size && harr[l] > harr[i])
                    largest = l;
                if (r < heap_size && harr[r] > harr[largest])
                    largest = r;
                if (largest != i)
                {
                    int t = harr[i];
                    harr[i] = harr[largest];
                    harr[largest] = t;
                    maxHeapify(largest);
                }
            }
        }

        // Function to return k'th largest element in a given
        // array

        int kthSmallest(int[] arr, int n, int k)
        {

            // Build a heap of first k elements: O(k) time
            MaxHeap mh = new MaxHeap(arr, k);

            // Process remaining n-k elements.  If current
            // element is smaller than root, replace root with
            // current element
            for (int i = k; i < n; i++)
                if (arr[i] < mh.getMax())
                    mh.replaceMax(arr[i]);

            // Return root
            return mh.getMax();
        }

        public void KthLargest(int[] arr, int size, int k)
        {

            // Creating Min Heap for given
            // array with only k elements
            // Create min heap with priority queue
            List<int> minHeap = new List<int>();
            for (int i = 0; i < k; i++)
            {
                minHeap.Add(arr[i]);
            }

            // Loop For each element in array
            // after the kth element
            for (int i = k; i < size; i++)
            {
                minHeap.Sort();

                // If current element is smaller 
                // than minimum ((top element of
                // the minHeap) element, do nothing 
                // and continue to next element
                if (minHeap[0] > arr[i])
                    continue;

                // Otherwise Change minimum element
                // (top element of the minHeap) to 
                // current element by polling out 
                // the top element of the minHeap
                else
                {
                    minHeap.RemoveAt(0);
                    minHeap.Add(arr[i]);
                }
            }

            // Now min heap contains k maximum
            // elements, Iterate and print   
            foreach (int i in minHeap)
            {
                Console.Write("k th largest element" + i + " ");
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 11, 3, 2, 1, 15, 5, 4,
                  45, 88, 96, 50, 45 };
            int n = arr.Length, k = 3;
            int l = arr[0];
            // int r = arr[arr.Length];
            GFG gfg = new GFG();
            gfg.KthLargest(arr, n, k);
            Console.Write("K'th smallest element is "
                          + gfg.kthSmallest(arr, n - 1, k));
            //for (int i =0;i<arr.Length-1;i++) 
            //Console.Write("    "+arr[i]);

        }
    }
}

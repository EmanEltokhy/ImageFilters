using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    internal class trying
    {
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
            if (CI >= N)
                CI = N - 1;
            if (CJ >= N)
                CJ = N - 1;
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
            array[(N * N) - 1] = index++;
            return array;
        }
    }
}

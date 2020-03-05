using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Algs_and_Complexity_Assignment_1
{
    public class Sorting_Algorithms
    {
        private int _ReferenceIndex = 10, _operations = 0, _interval = 10;
        public int ReferenceIndex
        {
            get { return _ReferenceIndex; }
            set
            {
                switch (value)
                {
                    case 0:
                        _ReferenceIndex += interval;
                        break;
                    case 10:
                        _ReferenceIndex = 10;
                        break;
                    case 50:
                        _ReferenceIndex = 50;
                        break;
                }
                
            } 
        }
        public int interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
            }
        }

        public int operations
        {
            get { return _operations; }
            set
            {
                if (value == 0)
                {
                    _operations += 1;
                }
                if (value == 1)
                {
                    _operations = 0;
                };

            }
        }


        public List<int> Net_1_256 = new List<int>(),
            Net_2_256 = new List<int>(),
            Net_3_256 = new List<int>(),
            Net_1_2048 = new List<int>(),
            Net_2_2048 = new List<int>(),
            Net_3_2048 = new List<int>(),
            Test = new List<int>();

        public void Populate_Lists()
        {
            Net_1_256 = Array.ConvertAll(File.ReadAllLines(@"Net_1_256.txt"), s => int.Parse(s)).ToList();
            Net_2_256 = Array.ConvertAll(File.ReadAllLines(@"Net_2_256.txt"), s => int.Parse(s)).ToList();
            Net_3_256 = Array.ConvertAll(File.ReadAllLines(@"Net_3_256.txt"), s => int.Parse(s)).ToList();
            Net_1_2048 = Array.ConvertAll(File.ReadAllLines(@"Net_1_2048.txt"), s => int.Parse(s)).ToList();
            Net_2_2048 = Array.ConvertAll(File.ReadAllLines(@"Net_2_2048.txt"), s => int.Parse(s)).ToList();
            Net_3_2048 = Array.ConvertAll(File.ReadAllLines(@"Net_3_2048.txt"), s => int.Parse(s)).ToList();
            Test = Array.ConvertAll(File.ReadAllLines(@"Test.txt"), s => int.Parse(s)).ToList();
            Console.WriteLine("");
        }

        public List<int> Get_Tenth(List<int> array, int selectedInterval)
        {

            ReferenceIndex = selectedInterval;
            List<int> tenths = new List<int>();
            while(ReferenceIndex <= array.Count)
            {
                tenths.Add(array[ReferenceIndex-1]);
                ReferenceIndex = 0;
            }
            ReferenceIndex = interval;
            return tenths;

        }

        public int Find_Value()
        {
            return 1;
        }

       


        //sorts
        public List<int> Merge_Sort(List<int> array, bool asc)
        {
            int mid = array.Count / 2;
            List<int> lefthalf = new List<int>(),
                righthalf = new List<int>();
            if (array.Count > 1)
            {
                for (int count = 0; count < array.Count; count++)
                {
                    if (count < mid)
                    {
                        lefthalf.Add(array[count]);
                    }
                    if (count >= mid)
                    {
                        righthalf.Add(array[count]);
                    }
                }


                Merge_Sort(lefthalf, asc);
                Merge_Sort(righthalf, asc);
                int i = 0, j = 0, k = 0;

                while (i < lefthalf.Count && j < righthalf.Count)
                {

                    if (lefthalf[i] < righthalf[j] && asc)
                    {
                        array[k] = lefthalf[i];
                        i++;
                    }
                    else
                    {
                        if (lefthalf[i] > righthalf[j] && !asc)
                        {
                            array[k] = lefthalf[i];
                            i++;
                        }
                        else
                        {
                            array[k] = righthalf[j];
                            j++;
                        }
                    }
                    k++;
                    operations = 0;
                }
                while (i < lefthalf.Count)
                {
                    array[k] = lefthalf[i];
                    i++;
                    k++;
                }
                while (j < righthalf.Count)
                {
                    array[k] = righthalf[j];
                    j++;
                    k++;
                }
            }
            return array;
        }
        public List<int> Bubble_Sort(List<int> array, bool asc)
        {
            int number = array.Count();
            for (int i = 0; i < number - 1; i++)
            {
                for (int j = 0; j < number - 1; j++)
                {
                    if (array[j + 1] < array[j] && asc)
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                    if (array[j + 1] > array[j] && !asc)
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                    operations = 0;
                }
            }



            return array;
        }
        public List<int> Insertion_Sort(List<int> array, bool asc)
        {
            int numSorted = 1, index;
            while (numSorted < array.Count)
            {
                int temp = array[numSorted];
                for (index = numSorted; index > 0; index--)
                {
                    if (temp < array[index - 1] && asc)
                        array[index] = array[index - 1];
                    else
                    {
                        if (temp > array[index - 1] && !asc)
                            array[index] = array[index - 1];
                        else break;
                    }


                }
                array[index] = temp;
                numSorted++;
                operations = 0;
            }
            return array;
        }

        public List<int> Quick_Sort(List<int> array, bool asc)
        {
            return Recursion(array, 0, array.Count - 1, asc);
        }
        private List<int> Recursion(List<int> array, int left, int right, bool asc)
        {
            int i = left,
                j = right,
                pivot = array[(left + right) / 2],
                temp;
            do
            {
                if (asc)
                {
                    while (array[i] < pivot && i < right) i++;
                    while (pivot < array[j] && j > left) j--;
                }
                else
                {
                    while (array[i] > pivot && i < right) i++;
                    while (pivot > array[j] && j > left) j--;
                }
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
                operations = 0;
            } while (i <= j);
            if (left < j)
                Recursion(array, left, j, asc);
            if (i < right)
                Recursion(array, i, right, asc);
            return array;

        }
    }
}

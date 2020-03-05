using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Algs_and_Complexity_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string sorting, filesort = "", orderby;
            int operations = 0,TenFift = 10;
            List<int> File = new List<int>(),
                tenths = new List<int>();
            var l = new Sorting_Algorithms();
            l.Populate_Lists();

            Console.WriteLine("What file is to be sorted");
            Console.WriteLine("1) Net_1_256 \n2) Net_2_256 \n3) Net_3_256 \n4) Net_1_2048 \n5)Net_2_2048 \n6)Net_3_2048");
            int file = Verify_value();
            switch (file)
            {
                case 1:;
                    filesort = "Net_1_256";
                    File = l.Net_1_256;
                    break;
                case 2:;
                    filesort = "Net_2_256";
                    File = l.Net_2_256;
                    break;
                case 3:;
                    filesort = "Net_3_256";
                    File = l.Net_3_256;
                    break;
                case 4:;
                    filesort = "Net_1_2048";
                    File = l.Net_1_2048;
                    TenFift = 50;
                    break;
                case 5:;
                    filesort = "Net_2_2048";
                    File = l.Net_2_2048;
                    TenFift = 50;
                    break;
                case 6:
                    filesort = "Net_3_2048";
                    File = l.Net_3_2048;
                    TenFift = 50;
                    break;
                default:
                    Console.WriteLine("Error Net_1_256 Selected by default:");
                    filesort = "Test";
                    File = l.Test;
                    break;
            }
            Console.Clear();


            Console.WriteLine("Do you want it sorted in:");
            Console.WriteLine("1) Ascending \n2) Descending");
            int asci = Verify_value();
            bool asc = true;
            switch (asci)
            {
                case 1:
                    orderby = "Ascending";
                    break;
                case 2:
                    orderby = "Descending";
                    asc = false;
                    break;
                default:
                    orderby = "Ascending";
                    break;

            }
            Console.Clear();
            
            Console.WriteLine("which Sorting algorithm would you like to use?");
            Console.WriteLine("1) Merge Sort\n2) Quick Sort\n3) Insertion Sort\n4) Bubble Sort");
            int sortingChoice = Verify_value();
            Console.Clear();
            switch (sortingChoice)
            {
                case 1:
                    File = l.Merge_Sort(File, asc);
                    operations = l.operations;
                    sorting = "Merge";
                    break;
                case 2:
                    File = l.Quick_Sort(File, asc);
                    operations = l.operations;
                    sorting = "Quick";
                    break;
                case 3:
                    File = l.Insertion_Sort(File, asc);
                    operations = l.operations;
                    sorting = "Insertion";
                    break;
                case 4:
                    File = l.Bubble_Sort(File, asc);
                    operations = l.operations;
                    sorting = "Bubble";
                    break;
                default:
                    File = l.Merge_Sort(File, asc);
                    operations = l.operations;
                    sorting = "Merge";
                    break;
            }


            Console.WriteLine($" you selected the {sorting} Sort\n performed on {filesort}\n and ordered in {orderby}");
            Console.WriteLine($"Number of Operations = {operations}");
            Console.WriteLine($"now that the Array has been sorted would you like to: \n1) display every {TenFift}th value\n2) Search the Array ");
            Console.Write("\n");
            int searchorShow = Verify_value();
            switch (searchorShow)
            {
                case 1:
                    foreach (int k in l.Get_Tenth(File,TenFift))
                    {
                        Console.Write($"{k}, ");
                    }
                    break;
                case 2:
                    Searching(File,asc);
                    break;
                default:
                    break;

            }
            Console.Write("\n");
            

        }

        public static int Verify_value()
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    int ToConvert = Convert.ToInt32(Console.ReadLine());
                    exit = true;
                    return ToConvert;
                }
                catch
                {
                    Console.WriteLine("There has been an error try again");
                }
            }
            return 1;
        }
        public static void Searching(List<int> SortedArray,bool asc)
        {
            var x = new Searching_Algorithms();
            string search = "Linear";
            List <int> Indexes = new List<int>();
            Console.Clear();
            Console.WriteLine("What Search would you like to perform: \n1) Linear Search \n2) Binary Search");
            int SearchingChoice = Verify_value();
            switch (SearchingChoice)
            {
                case 1:
                    break;
                case 2:
                    search = "Binary";
                    break;
                default:
                    break;  
            }
            Console.WriteLine("What value would you like to search for?");
            int ValueSearch = Verify_value();
            switch (search)
            {
                case "Linear":
                    Indexes = x.Linear_Search(SortedArray, ValueSearch,asc);
                    break;
                case "Binary":
                    Indexes = x.Binary_Search(SortedArray, ValueSearch,asc);
                    break;
                default:
                    Indexes = x.Linear_Search(SortedArray, ValueSearch,asc);
                    break;
            }
            if(SortedArray[Indexes[0]] != ValueSearch)
            {
                Console.WriteLine($"The number cannot be found \n the closest value to it however is at Index: {Indexes[0]}, Value: {SortedArray[Indexes[0]]}\n which is {ValueSearch -SortedArray[Indexes[0]]} away from the target {ValueSearch}");
            }
            else
            {
                Console.WriteLine($"The Value has been found at index(es): ");
                foreach (int k in Indexes)
                {
                    Console.Write($"{k}, ");
                }
            }

        }
    }
   


    public class Searching_Algorithms
    {
        public List<int> Binary_Search(List<int> array, int ValueFind,bool asc)
        {
            List<int> Indexes = new List<int>();
            int index = -1,
                first = 0,
                last = array.Count - 1,
                midpoint,
                temp = 1;
            while (first <= last)
            {
                midpoint = Convert.ToInt32(Math.Floor((double)((first + last) / 2)));
                if (array[midpoint] == ValueFind)
                {
                    if(temp == index)
                    {
                        break;
                    }
                    else
                    {
                        Indexes.Add(midpoint);
                        index = midpoint;
                    }
                    
                }
                else
                {
                    if (asc)
                    {
                        if (array[midpoint] < ValueFind)
                        {
                            first = midpoint + 1;
                        }
                        else
                        {
                            last = midpoint - 1;
                        }
                    }
                    else
                    {
                        if (array[midpoint] > ValueFind)
                        {
                            first = midpoint + 1;
                        }
                        else
                        {
                            last = midpoint - 1;
                        }
                    }

                }
                temp = midpoint;
            }
            if (index == -1 && first > last)
            {
                if (asc)
                {
                    if ((array[first] - ValueFind) < (ValueFind - array[last]))
                        Indexes.Add(first);
                    else
                        Indexes.Add(last);
                }
                else
                {
                    if ((array[first] - ValueFind) > (ValueFind - array[last]))
                        Indexes.Add(first);
                    else
                        Indexes.Add(last);
                }
                
            }
            return Indexes;
        }

        public List<int> Linear_Search(List<int> array, int ValueFind, bool asc)
        {
            List<int> MultipleIndex = new List<int>();
            int TempHoldL = 0, TempHoldH = array.Count - 1;
            bool Found = false;
            for(int i = 0; i < array.Count(); i++)
            {
                if(array[i] == ValueFind)
                {
                    MultipleIndex.Add(i);
                    Found = true;
                }
                else
                {
                    if (asc)
                    {
                        if (array[i] < ValueFind)
                            TempHoldL = i;
                        else
                        {
                            TempHoldH = i;
                            break;
                        }
                    }
                    else
                    {
                        if (array[i] > ValueFind)
                            TempHoldL = i;
                        else
                        {
                            TempHoldH = i;
                            break;
                        }
                    }
                   
                }
            }
            Console.WriteLine($"Low: {TempHoldL}, High: {TempHoldH}");
            if (!Found)
            {
                if (asc)
                {
                    if ((array[TempHoldH] - ValueFind) < (ValueFind - array[TempHoldL]))
                        MultipleIndex.Add(TempHoldH);
                    else
                        MultipleIndex.Add(TempHoldL);
                }
                else
                {
                    if ((array[TempHoldH] - ValueFind) > (ValueFind - array[TempHoldL]))
                        MultipleIndex.Add(TempHoldH);
                    else
                        MultipleIndex.Add(TempHoldL);
                }
                
            }            
            return MultipleIndex;
        }
    }
}


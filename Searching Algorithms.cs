using System;
using System.Collections.Generic;
using System.Text;

namespace Algs_and_Complexity_Assignment_1
{
    public class Searching_Algorithms
    {
        //Method Name: Binary Search
        //Purpose: to perform a binary search returning the index(es) of a value within the sorted list
        //          if not found returns closest value
        //Return Type: List<int>
        public List<int> Binary_Search(List<int> array, int ValueFind,bool asc)
        {
            List<int> Indexes = new List<int>();
            int index = -1,
                first = 0,
                last = array.Count - 1,
                midpoint,
                temp = 1;
            //beginning of binary search
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
                        for(int i =1; i < array.Count; i++)
                        {
                            if (array[midpoint + i] == ValueFind)
                                Indexes.Add(midpoint + i);
                            else
                            {
                                if (array[midpoint - i] == ValueFind)
                                    Indexes.Add(midpoint - i);
                                if (array[midpoint - i] != ValueFind && array[midpoint + i] != ValueFind)
                                    break;
                            }
                           
                        }
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
                try
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
                catch
                {
                    Indexes.Add(0);
                }


            }
            return Indexes;
        }

        //Method Name: Linear_Search
        //Purpose: to perform a linear search returning all indexes 
        //Return Type:
        public List<int> Linear_Search(List<int> array, int ValueFind, bool asc)
        {
            List<int> MultipleIndex = new List<int>();
            int TempHoldL = 0, TempHoldH = array.Count - 1;
            bool Found = false;
            for(int i = 0; i < array.Count; i++)
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

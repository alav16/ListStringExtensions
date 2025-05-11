/*
Add(item)	                     Adds a single item to the end of the list.
AddRange(collection)	         Adds multiple items to the list.
Insert(index, item)              Inserts an item at a specific position.
Remove(item)	                 Removes the first occurrence of an item.
RemoveAt(index)                  Removes the item at a given index.
Clear()	                         Removes all elements from the list.
Contains(item)	                 Checks if the item exists in the list.
IndexOf(item)	                 Returns the index of the first occurrence.
Find(predicate)	                 Finds the first item that matches a condition.
Exists(predicate)	             Returns true if any item matches a condition.
ForEach(action)	                 Applies an action to every element.
Sort()	                         Sorts the list (alphabetically/numerically).
Reverse()	                     Reverses the list order.
ToArray()	                     Converts the list to an array.
void Shuffle()                   պատահականության սկզբունքով խառնել բոլոր տարրերի դիրքերը
void Reverse()                   շրջել List-ը
List<T> Slice(int start,int end) կտրում և վերադարձնում է start-ից end հատվածի տարրերը:
T At(int index)                  վերադարձնում է index-րդ տարրը.  եթե index<0, հաշվարկը հակառակ կողմից իրականացնել
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ListTExt
{

    public static class ListExtend
    {
        private static Random rand = new Random();
        
        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                int j = rand.Next(i, n);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        public static void Reverse<T>(this List<T> list)
        {
            int left = 0;
            int right = list.Count - 1;
            while (left < right)
            {
                (list[left], list[right]) = (list[right], list[left]);
                left++;
                right--;
            }
        }

        public static List<T> Slice<T>(this List<T> list, int start, int end)
        {
            List<T> result = new List<T>();
            if (start < 0)
            {
                start = list.Count + start;
            }
            if (end < 0)
            {
                end = list.Count + end;
            }
            start = Math.Max(0, start);
            end = Math.Min(list.Count, end);

            for (int i = start; i < end; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }

        public static T At<T>(this List<T> list, int index)
        {
            if (index < 0)
            {
                index = list.Count + index;
            }

            if (index < 0 || index >= list.Count)
            {
                throw new ArgumentOutOfRangeException("index is invalid");
            }
            return list[index];
        }

        //public static void Add<T>(this List<T> list, )
        //public static void AddRange<T>(this List<T> list, IEnumerable<T> collection)
        //{
        //    foreach(var item in collection)
        //    {
        //        list.Add(item);
        //    }
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            numbers.Shuffle();
            Console.WriteLine(string.Join(", ", numbers));

            //var newNum = new List<int>() { 8, 9, 10 };
            //numbers.AddRange(newNum);
            //Console.WriteLine(string.Join(", ", numbers));

            numbers.Reverse();
            Console.WriteLine(string.Join(", ", numbers));

            var sliced = numbers.Slice(1, 4);
            Console.WriteLine(string.Join(", ", sliced));

            Console.WriteLine(numbers.At(2));
            Console.WriteLine(numbers.At(-1));
        }
    }
}

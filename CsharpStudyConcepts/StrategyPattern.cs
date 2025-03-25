using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public interface ISortStrategy
    {
        int[] Sort(int[] data);
    }

    public class BubbleSortStrategy : ISortStrategy
    {
        public int[] Sort(int[] data)
        {
            int[] arr = (int[])data.Clone();
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n-j-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    { 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
    }

    public class QuickSortStrategy : ISortStrategy
    {
        public int[] Sort(int[] data)
        {

            int[] arr = (int[])data.Clone();
            this.QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }

    public class Sorter
    {
        private ISortStrategy strategy;
        public void SetStrategy(ISortStrategy strategy) => this.strategy = strategy;
        public int[] Sort(int[] data)=> strategy.Sort(data);
    }


    internal class StrategyPattern
    {
        public static void StrategyPatternDemo()
        {
            int[] data = { 5, 2, 3, 5, 1, 7, 8, 4 };

            Sorter sorter = new Sorter();

            sorter.SetStrategy(new BubbleSortStrategy());
            Console.WriteLine("Bubble Sort: " + string.Join(", ", sorter.Sort(data)));

            sorter.SetStrategy(new QuickSortStrategy());
            Console.WriteLine("Quick Sort: " + string.Join(", ", sorter.Sort(data)));
        }
    }
}

namespace CsharpStudyConcepts;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Linq;
using System.Threading.Tasks;


class Program
{ 
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        #region twoSums
        TwoSums twoSums = new TwoSums();
        int[] nums = [2, 7, 11, 15];
        int target = 9;

        int?[] outVal = twoSums.SumTwoSum(nums, target);
        foreach (var val in outVal)
        {
            Console.WriteLine($"output: {val}");
        }
        #endregion

        #region subString
            LongestSubString subString = new LongestSubString();
            string fullLengthString = "abcdabc";
            var outputMaxLength = subString.SubString(fullLengthString);
            Console.WriteLine($"output: {outputMaxLength}");


        #endregion

        #region linkLists
            LinkedList.LinkedListDemo();
        #endregion


        #region concurrentData
            int[] ints = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
            ConcurrentDataProcessor concurrentDataProcessor = new ConcurrentDataProcessor();
            var sumLinqResult = concurrentDataProcessor.SumLinq(ints);
            Console.WriteLine($"output: {sumLinqResult}");

            var sumParallelResult = concurrentDataProcessor.SumParallel(ints);
            Console.WriteLine($"output: {sumParallelResult}");
        #endregion

        #region asyncFileProcessing

        #endregion

        #region UsbDecoder
        IProtocolDecoder usbDecode = new UsbDecoder();

        // Create some sample data (for example, the ASCII bytes for "Hello")
        byte[] sampleData = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };

        usbDecode.Decode(sampleData);
        #endregion

        #region singleton
            Logger.Instance.Log("singleton pattern");
        #endregion

        #region factoryPattern
            Creator creatorA = new ConcreteCreatorA();
            Console.WriteLine(creatorA.SomeOperation());

            Creator creatorB = new ConcreteCreatorB();
            Console.WriteLine(creatorB.SomeOperation());
        #endregion

    }
}

public class StringReversal
{
    public string StringReverser(string str)
    {
        return string.Join(" ", str.Split(' ').Reverse());
    }
}

public class ConcurrentDataProcessor
{
    public int SumLinq(int[] inputInts)
    {
        return inputInts.AsParallel().Sum();
    }

    public int SumParallel(int[] inputInts)
    {
        object lockObj = new object();
        int totalSum = 0;
        Parallel.ForEach(inputInts, num =>
        {
            lock (lockObj)
            {
                totalSum += num;
            }
        });
        return totalSum;
    }
}

class TwoSums
{
    public int?[] SumTwoSum(int[] nums, int target)
    {
        int?[] indicesOfTwoSums = new int?[2];
        int indexCounter = 0;
        int sumIndexCounter = 0;
        foreach (var num in nums)
        { 
            int difference = Math.Abs(num - target);

            if( difference == nums[indexCounter + 1] )
            {
                indicesOfTwoSums[sumIndexCounter] = indexCounter;
                indicesOfTwoSums[++sumIndexCounter] = indexCounter + 1;
                return indicesOfTwoSums;
            }
        }
        return indicesOfTwoSums = null;
    }
}

class LongestSubString
{
    public int SubString(string fullLengthString)
    {
        HashSet<char> set = new HashSet<char>();
        int left = 0; int maxLength = 0;

        for(int right = 0;  right < fullLengthString.Length; right++)
        {
            while (set.Contains(fullLengthString[right]))
            {
                set.Remove(fullLengthString[left++]);
            }

            set.Add(fullLengthString[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

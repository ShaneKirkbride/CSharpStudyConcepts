using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public class ListNode
    {
        private readonly int val;
        private ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public int Val { get { return val; } }
        public ListNode Next { get { return next; } set { next = value; } }

        public static ListNode ArrayToListNode(int[] inputArray)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;

            foreach(var input in inputArray)
            {
                current.Next = new ListNode(input);
                current = current.Next;
            }
            return dummy.next;
        }

        public static int[] ListNodeToArray(ListNode node)
        {
            var list = new List<int>();
            while (node != null)
            {
                list.Add(node.val);
                node = node.Next;
            }
            return list.ToArray();
        }
    }

    public class MergeKLinkedLists
    {
        public MergeKLinkedLists()
        {

        }

        public ListNode MergeKLists(ListNode[] array)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }

            PriorityQueue<ListNode, int> priorityQueue = new PriorityQueue<ListNode, int>();

            foreach (var node in array)
            {
                if (node != null)
                {
                    priorityQueue.Enqueue(node, node.Val);
                }
            }

            ListNode dummy = new ListNode(0);
            ListNode tail = dummy;

            while (priorityQueue.Count > 0)
            {
                ListNode minNode = priorityQueue.Dequeue();
                tail.Next = minNode;
                tail = minNode;

                if (minNode.Next != null)
                {
                    priorityQueue.Enqueue(minNode.Next, minNode.Val);
                }
            }
            return dummy.Next;
        }
    }


    internal class LinkedList
    {
        public static void LinkedListDemo()
        {
            MergeKLinkedLists mergeKLinkedLists = new MergeKLinkedLists();
            ListNode[] lists =
            [
                ListNode.ArrayToListNode(new int[] { 1, 4, 5 }),
                ListNode.ArrayToListNode(new int[] { 1, 3, 4 }),
                ListNode.ArrayToListNode(new int[] { 2, 6 })
            ];

            var result = mergeKLinkedLists.MergeKLists(lists);
            var arrayResult = ListNode.ListNodeToArray(result);

            foreach (var item in arrayResult)
            {
                Console.WriteLine($"output merged K list: {item}");
            }
        }
    }
}

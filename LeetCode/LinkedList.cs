﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    [TestFixture]
    public class LinkedList
    {
        #region Reverse Linked List

        /*  https://leetcode.com/problems/reverse-linked-list/
         *  
         *  Reverse a singly linked list.

            Example:

            Input: 1->2->3->4->5->NULL
            Output: 5->4->3->2->1->NULL
            Follow up:

            A linked list can be reversed either iteratively or recursively. Could you implement both?
         */

      
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode sortedList = null;

            while (head != null) {
                ListNode tmpNext = head.next;
                head.next = sortedList;
                sortedList = head;
                head = tmpNext;
            }

            return sortedList;
        }
        [Test]
        public static void ReverseList()
        {
            ListNode InputLinkedList = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            ListNode output = ReverseList(InputLinkedList);

            Assert.AreEqual(true, true);
        }

        public static ListNode ReverseList_Iterative(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode rotatedLinkedList = null; // Our New List
            // We will start scanning Head Untill Head is Null
            // Save Next Node in Tmp
            // Set Head.Next as our Sorted List
            // Set Sorted List as Head
            // Set Head as Temp (which was original Next)
            while (head != null)
            {
                ListNode tmpNext = head.next;
                head.next = rotatedLinkedList;
                rotatedLinkedList = head;
                head = tmpNext;

                #region Explaination

                /*
                    Iternation 1
                        head 1->2->3->4->5->null
                        rotatedLinkedList = null
                        tmpNext = head.next = 2->3->4->5->null
                        head.next = rotatedLinkedList = null (this makes head = 1->null)
                        rotatedLinkedList = head = 1->null
                        head = tmpNext = 2->3->4->5->null
                    
                Iternation 2
                        head 2->3->4->5->null
                        rotatedLinkedList = 1->null
                        tmpNext = head.next = 3->4->5->null
                        head.next = rotatedLinkedList = 1->null (this makes head = 2->1->null)
                        rotatedLinkedList = head = 2->1->null
                        head = tmpNext = 3->4->5->null
                    
                Iternation 3
                        head 3->4->5->null
                        rotatedLinkedList = 2->1->null
                        tmpNext = head.next = 4->5->null
                        head.next = rotatedLinkedList = 2->1->null (this makes head = 3->2->1->null)
                        rotatedLinkedList = head = 3->2->1->null
                        head = tmpNext = 4->5->null
                
                Iternation 4
                        head 4->5->null
                        rotatedLinkedList = 3->2->1->null
                        tmpNext = head.next = 5->null
                        head.next = rotatedLinkedList = 3->2->1->null (this makes head = 4->3->2->1->null)
                        rotatedLinkedList = head = 4->3->2->1->null
                        head = tmpNext = 5->null
                
                Iternation 5
                        head 5->null
                        rotatedLinkedList = 4->3->2->1->null
                        tmpNext = head.next = null
                        head.next = rotatedLinkedList = 4->3->2->1->null (this makes head = 5->4->3->2->1->null)
                        rotatedLinkedList = head = 5->4->3->2->1->null
                        head = tmpNext = null
                */

                #endregion
            }

            return rotatedLinkedList;
        }

        [Test]
        public static void ReverseList_IterativeTest()
        {
            ListNode InputLinkedList = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            ListNode output = ReverseList_Iterative(InputLinkedList);

            Assert.AreEqual(true, true);
        }

        // Copied
        public static ListNode ReverseList_Recursive(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode newHead = ReverseList_Recursive(head.next);
            head.next.next = head;
            head.next = null;

            return newHead;
        }

        [Test]
        public static void ReverseList_RecursiveTest()
        {
            ListNode InputLinkedList = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            ListNode output = ReverseList_Recursive(InputLinkedList);

            Assert.AreEqual(true, true);
        }

        #endregion
    }
}
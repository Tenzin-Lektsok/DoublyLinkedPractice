using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LearnDoublyLinkedList
{
    //Doubly linked contain collections of element represented by nodes,thus create class Node,
    //Node contain data that is element value along memory addrees of immediate next Node as well as immediate prevouis Node. 
    public class Node
    {
        
        public int elememnt; // Variable type int
        public Node next; // Variable type next
        public Node prev; //Type Node

        //We create a constructor in the Node class 
        //because we want to initialize all three members Element, Next, and Prev at the same time when a new node is created."
        public Node(int e,Node n,Node p)
        {
           element =e;
           next = n;
           prev =p; 
        
        }
        
    }
        

    class DoublyLinkedList
    {
        //Within doubly linked list class we declare head of type node to store reference of first Node of doubly linked list
        private Node head;
        //Declare also type node to store reference of last node of doubly linked list
        private Node tail;
        // We declare a variable size to track and store the count of the number of nodes present in the doubly linked list at any given time."
        private int size;

        //Constructor  for class to intialize head,tail, and size member of doubly linked list.
        public DoublyLinkedList()
        {
           head = null; //No first node yet
            tail = null; //No last node yet
            size = 0; //Zero as intially doubly linked list is empty.
        }

       // Method to return the number of elements or length of the doubly linked list
       // as the size variable stores the count of elements in the doubly linked list.
        public int length()
        {
            return size;
        }    

        //Method isEmpty is implemented using a boolean to check whether the doubly linked list is empty or not.
        public bool isEmpty()
        {
            return size == 0;
        }

        // Method to insert a node at the end of the doubly linked list with the input parameter e.
        public void addLast(int e)
        {
            //new node is always created first, then if condition is always checked second, and size is always incremented last. 
            Node newest = new Node(e,null,null);

            if(isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else
            {
                //if doubly linked list is not empty, tail's next reference is connected to newest node, yet newest node's prev reference is not linked back to tail.
                tail.next = newest; 
              //newest node's prev reference is connected back to tail node,completing the backward link between newest and tail.
                newest.prev = tail;
                // tail reference is moved to newest node,after that the newest pointer will disappea as it is a temporary variable inside the method.
                tail = newest;
            }
            size++; //count is incremented by 1
        }    
        
        public void addFirst(int e)
        {
            Node newest = new Node(e, null, null);
            if (isEmpty())
            {
                //if list is empty then head and tail pointer to new node newest.
                head = newest;
                tail = newest;
            }
            else
            {
                //If list is not empty than add newest node at begining of list.
                newest.next = head; // forward link is created in list
                head.prev = newest; //backward link is created in list
                head = newest; //head pointer update to newest node as now it's first node of list.
            }
            size++; //update size or length of list by 1.
          
        }
        public void addAny(int e,int position)
        {
            // If position is less than or equal to 0, it is invalid because position cannot be negative or zero.
            // If position is 1, we insert at the beginning of the list, already handled by addFirst().
            // If position is greater than size, it is invalid because there is no node at that index to insert before.
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid Position");
            }
            Node newest = new Node(e, null, null);
            Node p = head;
            int i = 1;
            while(i< position - 1)
            {
                p =p.next; //move to next node.
                i++; //increment counter to track how many nodes we have traversed
            }
            // Link the new node to the next node so the remaining list is not lost
            newest.next = p.next;
            //Since it is a doubly linked list, update the previous link of the next node, so it now points back to the new node
            p.next.prev = newest;
            // Now connect the current node (p) to the new node in forward direction
            p.next = newest;
            //Complete the backward link from new node to p
            newest.prev = p;
            size++;// Increase the size of the list as one new node is added

        }
         public int RemoveFirst()
        {
            // // If the list is empty, we cannot remove any element, so we print a message and return -1.
            if (isEmpty())
            {
                Console.WriteLine("Doubly linked list is empty.");
                return -1;
            }
            // Save the data of the first node so we can return it at the end after head has moved forward.
            int e = head.element;
            // Move head forward to the second node, making it the new first node.
            // The old head node now has no reference pointing to it, so garbage collector will clean it up.
            head = head.next;
            // Decrease the size by one since we removed a node.
            size--;
            // If the list had only one node, after deleting it the list is now empty.
            // Head is already null from head = head.next, but tail is still pointing to the deleted node.
            // So we manually set tail to null.
            if (isEmpty())
            {
                tail = null;
            }
            else
            {
                // If the list had more than one node, the new head's prev is still pointing to the deleted node.
                // So we set head.prev to null to remove that broken link.
                head.prev = null;
            }
            return e;
        }

        public int removeLast()
        {
            // If the list is empty, we cannot remove any element, so we print a message and return -1.
            if (isEmpty())
            {
                Console.WriteLine("Doubly linked list is empty");
                return -1;
            }

            // Save the data of the last node so we can return it at the end after tail has moved backward.
            int e = tail.element;

            // Move tail backward to the previous node, making it the new last node.
            // The old tail node now has no reference pointing to it, so garbage collector will clean it up.
            tail = tail.prev;

            // The new tail's next is still pointing to the deleted node, so we set it to null to remove that broken link.
            tail.next = null;

            // Decrease the size by one since we removed a node.
            size--;

            // Return the saved data of the deleted node.
            return e;
        }

        public void display()
        {
            Node p = head; //To display list of items in doubly linked list, it must traverse via head as it's entry point to entire list.
           // While loop is implemented as the number of nodes in the doubly linked list is unpredictable, and the last node's next reference is always null,
           // thus the condition is not equal to null.
            while(p!= null)
            {
                Console.WriteLine(p.element + ": ");
                p = p.next;
            }
            //Add a new line after displaying all elements of the doubly linked list.
            Console.WriteLine();
        }
            
        static void Main(string[] args)
        {
              DoublyLinkedList myList = new DoublyLinkedList();
            Console.WriteLine("\naddLast Method: ");
            myList.addLast(7);
            myList.addLast(4);
            myList.addLast(12);
            myList.addLast(3);

            myList.display();

            Console.WriteLine("Size of doubly linked list is " + myList.length());
            Console.WriteLine("Is my list is empty: false mean not empty and true mean empty: "+ myList.isEmpty());

            bool empty = myList.isEmpty();
            if (empty)
            {
                Console.WriteLine("List is empty.");
            }
            else
            {
                Console.WriteLine("List is not empty.");
            }
            Console.WriteLine("\naddFirst Method: ");
            myList.addFirst(15);
            myList.display();
            Console.WriteLine($"Size of List is  { myList.length()}");

            Console.WriteLine("\naddAny Method: ");
            myList.addAny(23, 3);
            myList.display();
            Console.WriteLine($"Size of List is  {myList.length()}");

            Console.WriteLine("\nRemoveFirst method: ");
            int element = myList.RemoveFirst(); Console.WriteLine("Removed element: "+ element);
            myList.display();
            Console.WriteLine($"Size of list after removing first element is {myList.length()}");
            //link is https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
             //https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205582#content
            //https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205572#content
            //https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205560#content

            
            Console.ReadLine();

        }
    }
}

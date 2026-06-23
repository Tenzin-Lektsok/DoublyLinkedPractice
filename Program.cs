using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LearnDoublyLinkedList
{
    //Doubly linked contain collections of element represented by nodes,thus create class Node,
    //Node contain data that is element value along memory addrees of immediate next Node as well as immediate prevouis Node. 
    public Class Node
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

        
            
        static void Main(string[] args)
        {

        }
    }
}

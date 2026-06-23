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
        static void Main(string[] args)
        {

        }
    }
}

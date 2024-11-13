using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System;

public class LinkedListExample : MonoBehaviour
{
    [SerializeField] private LinkedList myLinkedList = new LinkedList();
    // Start is called before the first frame update
    void Start()
    {
        myLinkedList.AddFirst(1);
        myLinkedList.AddFirst(2);
        myLinkedList.AddFirst(3);

        Node current = myLinkedList.Head;
        while (current != null)
        {
            Debug.Log(current.Value);
            current = current.Next;
        }

    }

    [Serializable] public class Node
    {
        public int Value;
        public Node Next;
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }
    
    [Serializable] public class LinkedList
    {
        public Node Head;
        public void AddFirst(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
        }


        public void AddLast(int value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
    }
}

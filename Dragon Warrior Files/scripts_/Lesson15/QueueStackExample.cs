using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueStackExample : MonoBehaviour
{
    [SerializeField] private Queue<string> myQueue = new Queue<string>();

    [SerializeField] private Stack<string> myStack = new Stack<string>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Queue: ");

        myQueue.Enqueue("First");
        myQueue.Enqueue("Second");
        myQueue.Enqueue("Third");

        while (myQueue.Count > 0)
        {
            string item = myQueue.Dequeue();
            Debug.Log(item);
        }

        Debug.Log("_______________________");
        Debug.Log("Stack: ");


        myStack.Push("First");
        myStack.Push("Second");
        myStack.Push("Third");
        while (myStack.Count > 0)
        {
            string item = myStack.Pop();
            Debug.Log(item);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
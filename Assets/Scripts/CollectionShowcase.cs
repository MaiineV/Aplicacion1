using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionShowcase : MonoBehaviour
{
    public Dictionary<string, int> dic = new Dictionary<string, int>();
    public Queue<string> queue = new Queue<string>();
    public Stack<string> stack = new Stack<string>();

    private void Awake()
    {

    }

    private void StackTest()
    {
        stack.Push("c");
        stack.Push("d");

        Debug.Log(stack.Peek());
        Debug.Log(stack.Pop());
    }

    private void QueueTest()
    {
        queue.Enqueue("a");
        queue.Enqueue("b");

        Debug.Log(queue.Dequeue());

        Debug.Log(queue.Peek());
        Debug.Log(queue.Dequeue());
    }

    private void DiccTest()
    {
        dic.Add("Aplicacion 1", 116);
        dic.TryAdd("Aplicacion 1", 200);
        Debug.Log(dic["Aplicacion 1"]);

        dic["Aplicacion 1"] = 200;


        if (dic.ContainsKey("Aplicacion 1"))
            Debug.Log("Has key");



        dic.Remove("Aplicacion 1");


        dic.Clear();
    }
}

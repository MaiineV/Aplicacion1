using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListNode<T>
{
    public T actualValue { private set; get; }
    public ListNode<T> next { private set; get; }

    public ListNode(T value) 
    {
        actualValue = value;
    }

    public void SetNext(ListNode<T> newNext) 
    {
        next = newNext;
    }
}

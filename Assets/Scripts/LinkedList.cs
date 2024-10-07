using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList<T> /*where T : MonoBehaviour*/
{
    private ListNode<T> _first;
    private int _searchIndex;

    public LinkedList(T initValue)
    {
        _first = new ListNode<T>(initValue);
    }

    public void Add(T newObject)
    {
        AddRecursive(newObject, _first);
    }

    private void AddRecursive(T newObject, ListNode<T> actualNode)
    {
        Debug.Log(actualNode.actualValue);
        if (actualNode.next != null)
        {
            AddRecursive(newObject, actualNode.next);
        }
        else
        {
            Debug.Log(newObject);
            actualNode.SetNext(new ListNode<T>(newObject));
        }
    }

    public ListNode<T> GetValueByIndex(int searchIndex, int counter, ListNode<T> actualNode)
    {
        if (counter >= searchIndex)
        {
            return actualNode;
        }
        else
        {
            counter++;

            if (actualNode.next != null)
                return GetValueByIndex(searchIndex, counter, actualNode.next);
            else
                return null;

        }
    }
}


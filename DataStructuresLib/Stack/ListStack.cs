using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLib.Stack;

public class ListStack<T>
{
    private List<T> items = new List<T>();

    public ListStack()
    {

    }

    public ListStack(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Push(item);
        }
    }

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);

        return item;
    }

    public T Peek()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[items.Count - 1];
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public int Count()
    {
        return items.Count;
    }

    public void Clear()
    {
        items.Clear();
    }
}

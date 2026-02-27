using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DataStructuresLib.Stack;

public class ArrayStack<T> : IEnumerable<T>
{
    private T[] items;
    private int top = -1;
    private int capacity;
    
    public ArrayStack(int initialCapacity = 4)
    {
        capacity = initialCapacity;
        items = new T[capacity];
    }

    public void Push(T item)
    {
        // If the stack is full
        if (top == capacity - 1)
        {
            Resize();
        }

        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack underflow - cannot pop from empty stack");
        }

        var item = items[top];
        items[top] = default(T); // For GC
        top--;

        /// When the 25% of the stack is actually used we shrink it.
        if (top + 1 > 0 && top + 1 < capacity / 4 && capacity > 4)
        {
            Resize(0.5f);
        }

        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return items[top];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public void Clear()
    {
        Array.Clear(items, 0, top + 1);
        top = -1;
    }

    public int Count()
    {
        // or items.Length
        return top + 1;
    }

    public T[] ToArray()
    {
        T[] result = new T[Count()];

        for (int i = 0; i < Count(); i++)
        {
            result[i] = items[i];
        }

        return result;
    }

    private void Resize(double multiplier = 2)
    {
        capacity = (int)(capacity * multiplier);
        T[] newItems = new T[capacity];

        Array.Copy(items, newItems, top + 1);
        items = newItems;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = top; i >= 0; i--)
        {
            yield return items[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

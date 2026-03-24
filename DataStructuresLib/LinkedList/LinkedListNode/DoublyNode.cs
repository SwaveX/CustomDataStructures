using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLib.LinkedList.LinkedListNode;

public class DoublyNode<T>
{
    public T Value { get; set; }
    public DoublyNode<T>? Previous { get; internal set; }
    public DoublyNode<T>? Next { get; internal set; }

    public DoublyNode(T value)
    {
        Value = value;
    }
}

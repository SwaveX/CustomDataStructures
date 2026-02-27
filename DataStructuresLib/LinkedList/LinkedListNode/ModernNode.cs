using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLib.LinkedList.LinkedListNode;

public class ModernNode<T>
{
    public T Value { get; set; }
    public ModernNode<T>? Previous { get; internal set; }
    public ModernNode<T>? Next { get; internal set; }

    public ModernNode(T value)
    {
        Value = value;
    }
}

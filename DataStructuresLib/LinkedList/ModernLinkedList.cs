using DataStructuresLib.LinkedList.LinkedListNode;
using System.Collections;

namespace DataStructuresLib.LinkedList;


/// NOTE: Implement fully
public class ModernLinkedList<T> : IEnumerable<T>
{
    public ModernLinkedList()
    {

    }

    public ModernLinkedList(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        foreach (var item in collection)
        {
            AddLast(item);
        }
    }

    # region Properties
    public ModernNode<T>? Head { get; private set; }
    public ModernNode<T>? Tail { get; private set; }
    public int Count { get; private set; }
    #endregion Properties

    #region Insertion
    public ModernNode<T> AddFirst(T value)
    {
        var newNode = new ModernNode<T>(value);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        Count++;

        return newNode;
    }

    public ModernNode<T> AddLast(T value)
    {
        var newNode = new ModernNode<T>(value);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        Count++;

        return newNode;
    }

    public ModernNode<T> AddBefore(ModernNode<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node);

        var newNode = new ModernNode<T>(value);

        newNode.Previous = node.Previous;

        if (node.Previous != null)
        {
            (node.Previous).Next = newNode;
        }
        else
        {
            // node was the Head
            Head = newNode;
        }

        node.Previous = newNode;

        Count++;

        return newNode;
    }

    public ModernNode<T> AddAfter(ModernNode<T> node, T value)
    {
        throw new NotImplementedException();
    }
    #endregion Insertion

    #region Removal
    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public void Remove(ModernNode<T> node)
    {
        throw new NotImplementedException();
    }

    public void RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public void RemoveLast()
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
    #endregion Removal

    #region Search 
    public ModernNode<T>? Find(T value)
    {
        throw new NotImplementedException();
    }

    public ModernNode<T>? FindLast(T value)
    {
        throw new NotImplementedException();
    }

    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    #endregion Search 

    #region Utility
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Reverse()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion Utility
}

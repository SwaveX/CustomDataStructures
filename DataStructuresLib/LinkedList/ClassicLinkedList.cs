using DataStructuresLib.LinkedList.LinkedListNode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DataStructuresLib.LinkedList;

/// <summary>
/// Represents a generic singly linked list data structure that implements the IEnumerable interface.
/// </summary>
/// <typeparam name="T">The type of elements stored in the linked list.</typeparam>
public class ClassicLinkedList<T> : IEnumerable<T>
{
    /// <summary>
    /// Initializes a new instance of the CustomLinkedList class that is empty.
    /// </summary>
    public ClassicLinkedList()
    {

    }

    /// <summary>
    /// Initializes a new instance of the CustomLinkedList class that contains elements from the specified collection.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new list.</param>
    /// <exception cref="ArgumentNullException">Thrown when collection is null.</exception>
    public ClassicLinkedList(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        foreach (var item in collection)
        {
            AddLast(item);
        }
    }

    /// <summary>
    /// Gets the first node in the linked list, or null if the list is empty.
    /// </summary>
    public ClassicNode<T>? Head { get; private set; } = null;

    /// <summary>
    /// Gets the last node in the linked list, or null if the list is empty.
    /// </summary>
    public ClassicNode<T>? Tail { get; private set; } = null;

    /// <summary>
    /// Gets the number of nodes in the linked list.
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// Determines whether the linked list contains a specific value.
    /// </summary>
    /// <param name="value">The value to search for in the linked list.</param>
    /// <returns>True if the value is found; otherwise, false.</returns>
    public bool Contains(T value)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Finds and returns the first node containing the specified value.
    /// </summary>
    /// <param name="value">The value to search for in the linked list.</param>
    /// <returns>The node containing the specified value, or null if not found.</returns>
    public ClassicNode<T>? Find(T value)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// Adds a new node with the specified value at the beginning of the linked list.
    /// </summary>
    /// <param name="value">The value to add to the beginning of the list.</param>
    public void AddFirst(T value)
    {
        var newNode = new ClassicNode<T>(value);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }

        Count++;
    }

    /// <summary>
    /// Adds a new node with the specified value at the end of the linked list.
    /// </summary>
    /// <param name="value">The value to add to the end of the list.</param>
    public void AddLast(T value)
    {
        var newNode = new ClassicNode<T>(value);

        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }

        Count++;
    }

    /// <summary>
    /// Adds a new node with the specified value after the specified existing node.
    /// </summary>
    /// <param name="node">The node after which to insert the new value.</param>
    /// <param name="value">The value to add after the specified node.</param>
    /// <exception cref="ArgumentNullException">Thrown when node is null.</exception>
    public void AddAfter(ClassicNode<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node);

        ClassicNode<T> newNodeToAdd = new(value);

        if (node == Tail)
        {
            Tail.Next = newNodeToAdd;
            Tail = newNodeToAdd;
        }
        else
        {
            ClassicNode<T> oldNextNode = node.Next;
            node.Next = newNodeToAdd;
            newNodeToAdd.Next = oldNextNode;
        }

        Count++;
    }

    /// <summary>
    /// Removes the first node from the linked list.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
    public void RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }
        else if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head = Head.Next;
        }

        Count--;
    }

    /// <summary>
    /// Removes the last node from the linked list.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the list is empty.</exception>
    public void RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            ClassicNode<T> current = Head;
            while (current != null)
            {
                if (current.Next == Tail)
                {
                    current.Next = null;
                    Tail = current;

                    break;
                }

                current = current.Next;
            }
        }

        Count--;
    }

    /// <summary>
    /// Removes the first node containing the specified value from the linked list.
    /// </summary>
    /// <param name="value">The value to remove from the list.</param>
    /// <returns>True if a node with the specified value was removed; otherwise, false.</returns>
    public bool Remove(T value)
    {
        if (Count == 0)
        {
            return false;
        }

        ClassicNode<T> previous = null;
        ClassicNode<T> current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (previous == null)       // removing Head
                {
                    Head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                if (current == Tail)        // removing Tail
                {
                    Tail = previous;
                }

                Count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Removes all nodes from the linked list.
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>An enumerator for the linked list.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;

            current = current.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>An enumerator for the linked list.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

using DataStructuresLib.LinkedList;

namespace Tests_DataStructures;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("En thya phya, Phal y' Nax");

        int[] arr = { -1, 4, 5, -7 };
        ClassicLinkedList<int> myLst = new ClassicLinkedList<int>(arr);
        Console.WriteLine(myLst.Head.Value);
        Console.WriteLine(myLst.Head.Next.Value);
        Console.WriteLine(myLst.Head.Next.Next.Value);
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }
}

//public class LinkedList<T>
//{
//    public Node<T> Head { get; set; }
//    public Node<T> Tail { get; set; }
//    public int Count;

//    public LinkedList(params T[] nodes)
//    {
//        Console.WriteLine(nodes[0]);
//        Console.WriteLine();

//        Head = new Node<T> { Value = nodes[0] };
//        Tail = new Node<T> { Value = nodes[^1] };

//        while (Head != Tail)
//        {
//            Count++;
//            Head = Head.Next;
//        }

//        Head = Tail;
//    }

//    public void Clear()
//    {

//    }
//}

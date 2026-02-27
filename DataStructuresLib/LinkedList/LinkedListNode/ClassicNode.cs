namespace DataStructuresLib.LinkedList.LinkedListNode;

public class ClassicNode<T>
{
    public T Value { get; set; }
    public ClassicNode<T>? Next { get; internal set; }

    public ClassicNode(T value)
    {
        Value = value;
        Next = null;
    }
}

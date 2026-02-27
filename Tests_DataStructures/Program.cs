using DataStructuresLib.LinkedList;
using DataStructuresLib.Stack;

namespace Tests_DataStructures;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Data Structures Testing ===\n");

        TestClassicLinkedList();
        Console.WriteLine("\n" + new string('-', 50) + "\n");

        TestArrayStack();
        Console.WriteLine("\n" + new string('-', 50) + "\n");

        TestListStack();
        Console.WriteLine("\n" + new string('-', 50) + "\n");

        TestLinkedListStack();
        Console.WriteLine("\n" + new string('-', 50) + "\n");

        Console.WriteLine("All tests completed!");
    }

    static void TestClassicLinkedList()
    {
        Console.WriteLine("### ClassicLinkedList Tests ###\n");

        // Test 1: Empty list
        var list = new ClassicLinkedList<int>();
        Console.WriteLine($"Empty list count: {list.Count}"); // 0

        // Test 2: AddFirst
        list.AddFirst(10);
        list.AddFirst(20);
        list.AddFirst(30);
        Console.WriteLine($"After AddFirst (30, 20, 10): {string.Join(" -> ", list)}"); // 30 -> 20 -> 10

        // Test 3: AddLast
        list.AddLast(5);
        list.AddLast(1);
        Console.WriteLine($"After AddLast (5, 1): {string.Join(" -> ", list)}"); // 30 -> 20 -> 10 -> 5 -> 1

        // Test 4: Contains & Find
        Console.WriteLine($"Contains 10: {list.Contains(10)}"); // True
        Console.WriteLine($"Contains 99: {list.Contains(99)}"); // False
        var node = list.Find(10);
        Console.WriteLine($"Find(10) value: {node?.Value}"); // 10

        // Test 5: AddAfter
        list.AddAfter(node, 15);
        Console.WriteLine($"After AddAfter(10, 15): {string.Join(" -> ", list)}"); // 30 -> 20 -> 10 -> 15 -> 5 -> 1

        // Test 6: RemoveFirst
        list.RemoveFirst();
        Console.WriteLine($"After RemoveFirst: {string.Join(" -> ", list)}"); // 20 -> 10 -> 15 -> 5 -> 1

        // Test 7: RemoveLast
        list.RemoveLast();
        Console.WriteLine($"After RemoveLast: {string.Join(" -> ", list)}"); // 20 -> 10 -> 15 -> 5

        // Test 8: Remove specific value
        bool removed = list.Remove(15);
        Console.WriteLine($"Remove(15) success: {removed}"); // True
        Console.WriteLine($"After Remove(15): {string.Join(" -> ", list)}"); // 20 -> 10 -> 5

        // Test 9: Constructor with collection
        var list2 = new ClassicLinkedList<string>(new[] { "apple", "banana", "cherry" });
        Console.WriteLine($"From collection: {string.Join(" -> ", list2)}"); // apple -> banana -> cherry

        // Test 10: Clear
        list.Clear();
        Console.WriteLine($"After Clear, count: {list.Count}"); // 0

        // Test 11: Exception handling
        try
        {
            list.RemoveFirst();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected exception: {ex.Message}");
        }
    }

    static void TestArrayStack()
    {
        Console.WriteLine("### ArrayStack Tests ###\n");

        // Test 1: Basic Push/Pop
        var stack = new ArrayStack<int>(2); // Small initial capacity to test resizing
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"After Push(10, 20, 30), Count: {stack.Count()}"); // 3

        // Test 2: Peek
        Console.WriteLine($"Peek: {stack.Peek()}"); // 30

        // Test 3: Pop
        Console.WriteLine($"Pop: {stack.Pop()}"); // 30
        Console.WriteLine($"Pop: {stack.Pop()}"); // 20
        Console.WriteLine($"Count after 2 pops: {stack.Count()}"); // 1

        // Test 4: Test resizing (push many items)
        for (int i = 1; i <= 10; i++)
        {
            stack.Push(i * 10);
        }
        Console.WriteLine($"After pushing 10 more items, Count: {stack.Count()}"); // 11

        // Test 5: ToArray
        var array = stack.ToArray();
        Console.WriteLine($"ToArray: [{string.Join(", ", array)}]");

        // Test 6: IEnumerable (foreach)
        Console.Write("Foreach (LIFO order): ");
        foreach (var item in stack)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();

        // Test 7: Test shrinking (pop many items)
        while (stack.Count() > 2)
        {
            stack.Pop();
        }
        Console.WriteLine($"After popping to 2 items, Count: {stack.Count()}"); // 2

        // Test 8: IsEmpty
        Console.WriteLine($"IsEmpty: {stack.IsEmpty()}"); // False

        // Test 9: Clear
        stack.Clear();
        Console.WriteLine($"After Clear, IsEmpty: {stack.IsEmpty()}"); // True

        // Test 10: Exception handling
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected exception: {ex.Message}");
        }
    }

    static void TestListStack()
    {
        Console.WriteLine("### ListStack Tests ###\n");

        // Test 1: Empty constructor
        var stack = new ListStack<string>();
        Console.WriteLine($"Empty stack count: {stack.Count()}"); // 0

        // Test 2: Push & Peek
        stack.Push("first");
        stack.Push("second");
        stack.Push("third");
        Console.WriteLine($"After Push, Peek: {stack.Peek()}"); // third
        Console.WriteLine($"Count: {stack.Count()}"); // 3

        // Test 3: Pop
        Console.WriteLine($"Pop: {stack.Pop()}"); // third
        Console.WriteLine($"Pop: {stack.Pop()}"); // second
        Console.WriteLine($"Count after 2 pops: {stack.Count()}"); // 1

        // Test 4: Constructor with collection
        var stack2 = new ListStack<int>(new[] { 100, 200, 300 });
        Console.WriteLine($"From collection, Peek: {stack2.Peek()}"); // 300
        Console.WriteLine($"Count: {stack2.Count()}"); // 3

        // Test 5: IsEmpty
        Console.WriteLine($"IsEmpty: {stack2.IsEmpty()}"); // False

        // Test 6: Clear
        stack2.Clear();
        Console.WriteLine($"After Clear, IsEmpty: {stack2.IsEmpty()}"); // True

        // Test 7: Exception handling
        try
        {
            stack2.Peek();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected exception: {ex.Message}");
        }
    }

    static void TestLinkedListStack()
    {
        Console.WriteLine("### LinkedListStack Tests ###\n");

        // Test 1: Basic operations
        var stack = new LinkedListStack<double>();
        stack.Push(1.1);
        stack.Push(2.2);
        stack.Push(3.3);
        Console.WriteLine($"After Push, Count: {stack.Count}"); // 3
        Console.WriteLine($"Peek: {stack.Peek()}"); // 3.3

        // Test 2: Pop
        Console.WriteLine($"Pop: {stack.Pop()}"); // 3.3
        Console.WriteLine($"Pop: {stack.Pop()}"); // 2.2
        Console.WriteLine($"Count: {stack.Count}"); // 1

        // Test 3: Contains
        stack.Push(4.4);
        stack.Push(5.5);
        Console.WriteLine($"Contains 4.4: {stack.Contains(4.4)}"); // True
        Console.WriteLine($"Contains 9.9: {stack.Contains(9.9)}"); // False

        // Test 4: ToArray
        var array = stack.ToArray();
        Console.WriteLine($"ToArray: [{string.Join(", ", array)}]");

        // Test 5: IsEmpty
        Console.WriteLine($"IsEmpty: {stack.IsEmpty()}"); // False

        // Test 6: Clear
        stack.Clear();
        Console.WriteLine($"After Clear, IsEmpty: {stack.IsEmpty()}"); // True
        Console.WriteLine($"After Clear, Count: {stack.Count}"); // 0

        // Test 7: Exception handling
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected exception: {ex.Message}");
        }

        // Test 8: Complex type (strings)
        var stringStack = new LinkedListStack<string>();
        stringStack.Push("alpha");
        stringStack.Push("beta");
        stringStack.Push("gamma");
        Console.WriteLine($"String stack: {string.Join(", ", stringStack.ToArray())}");
    }
}


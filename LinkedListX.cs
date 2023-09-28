using CarXCodingExercises.Interfaces;

namespace CarXCodingExercises;

public class LinkedListX<T> : IListX<T>
    where T: IEquatable<T>
{
    private ListNode? _head = null;
    private int _size = 0;
    private class ListNode
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public ListNode? Next { get; set; } = null;
    }

    public int Count
    {
        get => _size;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("You got out of bounds of the linked list");
            ListNode node = GetNodeAtIndex(index);
            return node.Value;
        }
        set
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("You got out of bounds of the linked list");
            ListNode node = GetNodeAtIndex(index);
            node.Value = value;
        }
    }

    private ListNode GetNodeAtIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds of the list");
        }

        int nodeCount = 0;
        ListNode? requestedNode = _head;
        while (nodeCount < index)
        {
            requestedNode = requestedNode.Next;
            nodeCount++;
        }

        return requestedNode;
    }

    public int IndexOf(object item)
    {
        return IndexOf((T)item);
    }

    public void Insert(int index, object item)
    {
        Insert(index, (T)item);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds of the list");
        
        if (index == 0)
        {
            _head = _head?.Next;
        }
        else
        {
            ListNode nodeBeforeRemoved = GetNodeAtIndex(index - 1);
            nodeBeforeRemoved.Next = nodeBeforeRemoved.Next?.Next;
        }

        _size--;
    }

    
    public int Add(T item)
    {
        ListNode lastNode = GetNodeAtIndex(Count - 1);
        lastNode.Next = new ListNode(item);
        _size++;
        return Count;
    }

    public void Clear()
    {
        _head = null;
        _size = 0;
    }

    public bool Contains(T item)
    {
        int itemIndex = IndexOf(item);
        return itemIndex != -1;
    }

    public bool Remove(T item)
    {
        ListNode? node = _head;
        while (node?.Next is not null)
        {
            if (node.Next.Value.Equals(item))
            {
                node.Next = node.Next.Next;
                return true;
            }
            node = node.Next;
        }

        _size--;

        return false;
    }

    public int IndexOf(T item)
    {
        ListNode? node = _head;
        int nodeCounter = 0;
        while (node is not null)
        {
            if (node.Value.Equals(item)) return nodeCounter;
            node = node.Next;
            nodeCounter++;
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds of the list");
        ListNode nodeToInsert = new ListNode(item);
        if (index > 1)
        {
            ListNode nodeBeforeInserted = GetNodeAtIndex(index - 1);

            nodeToInsert.Next = nodeBeforeInserted.Next;
            nodeBeforeInserted.Next = nodeToInsert;
        } 
        else if (index == 1)
        {
            nodeToInsert.Next = _head;
            _head = nodeToInsert;
        }

        _size++;
    }
}
using System.Collections;

public class SingleLinkedList<T> : ICollection<T>
{
    private Node? _head;
    private Node? _tail;
    private int _count;

    public SingleLinkedList() { }

    public SingleLinkedList(IEnumerable<T> collection)
    {
        if(collection == null) throw new ArgumentNullException("list");
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public int Count => _count;

    public bool IsReadOnly => false;

    #region Adding Methods

    public void Add(T item)
    {
        AddToEnd(item);
    }

    public void AddToFront(T item)
    {
        var newNode = new Node(item, null);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            var tempHead = _head;
            _head = newNode;
            _head.Next = tempHead;
        }
        _count++;
    }

    public void AddToEnd(T? item)
    {
        var newNode = new Node(item, null);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }

        if (_tail == null)
        {
            Node currentTail = getTail();
            currentTail.Next = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++;
    }

    #endregion

    #region Removing Methods

    public bool Remove(T? item)
    {
        if (_head == null)
        {
            return false;
        }

        if (_head == _tail && !_head.Item!.Equals(item))
        {
            return false;
        }

        if (_head.Item!.Equals(item))
        {
            return RemoveFirst();
        }

        return RemoveSpecyficItem(item);
    }

    private bool RemoveFirst()
    {
        PopFirst();
        return true;
    }

    private bool RemoveSpecyficItem(T? item)
    {
        int counter = 0;
        Node? current = _head;
        // Set current for node with item equal to one in argument
        while (current != null && !EqualityComparer<T>.Default.Equals(current!.Item, item))
        {
            current = current.Next;
            counter++;
        }

        if (current == null)
        {
            return false;
        }

        // Delete reference to deleted Node from previous Node
        Node previous = GetPreviousNodeBefore(counter);

        if (current == _tail)
        {
            _tail = previous;
        }

        previous.Next = current!.Next;
        _count--;
        return true;
    }

    public T PopFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("This list is empty");
        }

        T? removedItem = _head.Item;
        _head = _head.Next;
        _count--;

        if (Count == 0)
        {
            _head = null;
            _tail = null;
        }

        return removedItem!;
    }

    public T PopLast()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("This list is empty");
        }

        T? deletedItem;

        // list has only one item
        if (_head == _tail)
        {
            return PopFirst();
        }

        // if tail was destroyed
        if (_tail == null)
        {
            _tail = getTail();
        }

        // Deleting reference to deleted tail from Node standing before tail
        Node previousBeforeTail = GetPreviousNodeBefore(this.Count - 1);
        previousBeforeTail.Next = null;

        deletedItem = _tail.Item;
        _tail = null;
        _count--;

        return deletedItem!;
    }

    #endregion

    #region Peeking Methods

    public T PeekFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }
        return _head.Item!;
    }

    public T PeekLast()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        if (_tail == null)
        {
            Node? currentTail = getTail();
            return currentTail.Item!;
        }

        return _tail.Item!;
    }

    #endregion

    #region Utility Methods

    public T GetAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
        }

        var counter = 0;
        Node? current = _head;

        while (counter < index)
        {
            current = current!.Next;
            counter++;
        }
        return current!.Item!;
    }

    /// <summary>
    /// Merges the provided list into the current list by appending all of its elements.
    /// After the merge, the provided list will be cleared.
    /// Beacuse List is working on reference type, and making operations on list that is merged to targeted list may broke it functionality, so it has to be cleared
    /// </summary>
    /// <param name="list">The list to merge into the current list.</param>
    public void Merge(SingleLinkedList<T> list)
    {
        if (list == null) 
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (list._head == null)
        {
            return;
        }

        if (_head == null)
        {
            _head = list._head;
            _tail = list._tail;
            _count = list.Count();
            list.Clear();
        }
        else
        {
            _tail!.Next = list._head;
            _tail = list._tail;
            _count += list.Count();
            list.Clear();
        }
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public bool Contains(T? item)
    {
        Node? current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Item, item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index cannot be negative.");
        }

        if (arrayIndex + Count > array.Length)
        {
            throw new ArgumentException("The destination array has insufficient space.");
        }

        Node? current = _head;
        while (current != null)
        {
            array[arrayIndex++] = current.Item!;
            current = current.Next!;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = _head;
        if (_head == _tail && _head != null)
        {
            current.Next = null;
        }
        while (current != null)
        {
            yield return current.Item!;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion

    #region Helper Methods

    private Node getTail()
    {
        Node? current = _head;
        while (current!.Next != null)
        {
            current = current.Next;
        }

        return current;
    }

    private Node GetPreviousNodeBefore(int index)
    {
        if (_head == _tail)
        {
            throw new InvalidOperationException("Cannot get previous on list with only one element");
        }
        if (index < 1 || index >= Count)
        {
            throw new ArgumentOutOfRangeException("index can be given between 1 and size of list");
        }
        Node? previous = _head;
        for (int i = 1; i <= index - 1; i++)
        {
            previous = previous!.Next;
        }
        return previous!;
    }

    #endregion

    private record Node
    {
        public Node(T? item, Node? next)
        {
            Next = next;
            Item = item;
        }

        public Node? Next { get; set; }
        public T? Item { get; init; }
    };
}
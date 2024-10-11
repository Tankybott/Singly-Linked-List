# SingleLinkedList<T>

This repository contains a C# implementation of a generic singly linked list, `SingleLinkedList<T>`. It is designed to provide efficient, dynamic list manipulation with support for adding, removing, peeking, and other utility operations.

## Features

- Implements `ICollection<T>` for compatibility with C# collections.
- Supports adding and removing elements from the front and end of the list.
- Contains utility methods like `Merge()`, `Clear()`, and `Contains()`.
- Provides enumeration through `IEnumerable<T>` implementation.
- Custom handling for `GetAt()` and `CopyTo()` methods.

## Optimized Single Linked List with Tail

This implementation of a singly linked list (`SingleLinkedList<T>`) includes a **tail pointer**, which allows for quick access to the end of the list. While the list remains singly linked to minimize resource usage, having the tail pointer optimizes operations that involve the end of the list.

### Tail Optimization

- **Efficient Tail Access**: The tail pointer enables fast additions to the end of the list without needing to traverse it. This is especially beneficial for operations like `AddToEnd()` and `PopLast()`.
  
- **Tail Recovery**: In cases where the tail is destroyed, the list will only search for a new tail when an operation requires it. This means that if no tail-dependent operations are called, the resources needed to locate the tail are not used, providing further optimization.

## Public Methods

- `Add(T item)`: Adds an item to the end of the list.
- `AddToFront(T item)`: Adds an item to the front of the list.
- `AddToEnd(T item)`: Adds an item to the end of the list.
- `Remove(T item)`: Removes the first occurrence of an item from the list.
- `PopFirst()`: Removes and returns the first item in the list.
- `PopLast()`: Removes and returns the last item in the list.
- `PeekFirst()`: Returns the first item without removing it.
- `PeekLast()`: Returns the last item without removing it.
- `Merge(SingleLinkedList<T> list)`: Merges another linked list into the current list.
- `Clear()`: Clears the list.
- `Contains(T item)`: Checks if the list contains a specific item.
- `CopyTo(T[] array, int arrayIndex)`: Copies the list elements to an array.
- `GetAt(int index)`: Returns the element at the specified index.

## Utility Methods

- `GetAt(int index)`: Retrieves an element at a specific position.
- `Merge(SingleLinkedList<T> list)`: Merges two linked lists.
- `Contains(T item)`: Checks if an item exists in the list.

## Merge Method

The `Merge(SingleLinkedList<T> list)` method merges another list into the current list. However, this operation is **destructive** to the list being merged in. This is by design to ensure efficiency, as:

- **Reference Preservation**: Since linked lists rely on reference types, modifying the merged list after the merge could break the integrity of the resulting combined list. To prevent this, the merged list is cleared after the operation, preserving the stability of the current list.


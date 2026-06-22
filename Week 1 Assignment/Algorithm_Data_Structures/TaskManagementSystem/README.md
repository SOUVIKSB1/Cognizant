# Exercise 5: Task Management System

## 1. Understanding Linked Lists

- **Singly Linked List**:
  - A collection of nodes where each node contains data and a single reference (`Next`) pointing to the subsequent node in the sequence.
  - Traversal is uni-directional (from head to tail).
  - Uses less memory per node since it only keeps one reference pointer.
- **Doubly Linked List**:
  - A collection of nodes where each node contains data, a reference pointing to the subsequent node (`Next`), and a reference pointing to the preceding node (`Prev`).
  - Traversal is bi-directional (forward and backward).
  - Uses more memory per node (two pointers) but allows easier deletion and backward navigation.

---

## 2. Time Complexity Analysis

Below is the complexity analysis of operations in our custom Singly Linked List (which maintains a `tail` pointer to optimize appends):

| Operation | Time Complexity (Best Case) | Time Complexity (Worst Case) | Time Complexity (Average Case) | Description |
|---|---|---|---|---|
| **Add** | $O(1)$ | $O(1)$ | $O(1)$ | With a tail pointer, appending at the end takes $O(1)$ time. |
| **Search** | $O(1)$ | $O(N)$ | $O(N)$ | Must traverse nodes sequentially; best case is if the item is at the head. |
| **Traverse** | $O(N)$ | $O(N)$ | $O(N)$ | Requires visiting every node once. |
| **Delete** | $O(1)$ | $O(N)$ | $O(N)$ | Deletion from head is $O(1)$; deleting from middle/tail requires traversing up to $N$ elements to locate the element and update pointers. |

---

## 3. Advantages of Linked Lists Over Arrays for Dynamic Data

1. **Dynamic Size**: Linked lists do not have a fixed size. They grow and shrink at runtime dynamically as memory is allocated for new nodes. No array resizing ($O(N)$ cost) is ever needed.
2. **Cheap Insertions and Deletions**: Once the pointer/node reference is found, inserting or deleting a node is a simple pointer assignment taking $O(1)$ time. No adjacent elements have to be shifted in memory.
3. **No Memory Wastage**: Memory is allocated only when a node is added, unlike arrays where you must pre-allocate memory that might never be used.

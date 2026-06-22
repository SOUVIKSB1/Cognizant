# Exercise 6: Library Management System

## 1. Understanding Search Algorithms

- **Linear Search**:
  - A simple search algorithm that starts at the first element and sequentially checks each element of the list until a match is found or the end of the list is reached.
  - Does not require the dataset to be in any specific order (works on unsorted data).
- **Binary Search**:
  - An efficient search algorithm that works on a sorted dataset by repeatedly dividing the search interval in half.
  - It compares the target value to the middle element. If they are not equal, the half in which the target cannot lie is eliminated, and the search continues on the remaining half.
  - Requires the dataset to be pre-sorted.

---

## 2. Complexity Comparison

| Search Method | Time Complexity (Best Case) | Time Complexity (Average Case) | Time Complexity (Worst Case) | Space Complexity |
|---|---|---|---|---|
| **Linear Search** | $O(1)$ | $O(N)$ | $O(N)$ | $O(1)$ |
| **Binary Search** | $O(1)$ | $O(\log N)$ | $O(\log N)$ | $O(1)$ |

---

## 3. When to Use Each Algorithm

### Linear Search is preferred when:
- **Small Dataset**: For small collections (e.g., $<50$ books), the overhead of sorting the array for binary search outweighs the sequential scan speed.
- **Unsorted & Frequently Changing Data**: If the list is frequently updated (insertions/deletions) and rarely searched, keeping the list sorted is too expensive, making linear search more practical.
- **Unordered Collections**: Storing data in structures like unsorted linked lists or hash maps (when searching by non-key properties).

### Binary Search is preferred when:
- **Large Dataset**: For large library inventories (e.g., thousands or millions of books), $O(\log N)$ is extremely fast, while $O(N)$ causes significant lag.
- **Static or Read-Heavy Data**: If books are added occasionally but searched very frequently, sorting the array once (cost of $O(N \log N)$) is highly efficient since we can perform millions of $O(\log N)$ searches on it.

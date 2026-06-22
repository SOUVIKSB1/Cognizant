# Exercise 3: Sorting Customer Orders

## 1. Understanding Sorting Algorithms

- **Bubble Sort**:
  - A simple, comparison-based algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.
  - *Time Complexity*: $O(N^2)$ average and worst-case; $O(N)$ best-case (if already sorted).
  - *Space Complexity*: $O(1)$ auxiliary (in-place).
- **Insertion Sort**:
  - Builds the final sorted array one item at a time by consuming one input element each repetition and growing a sorted list behind it.
  - *Time Complexity*: $O(N^2)$ average and worst-case; $O(N)$ best-case.
  - *Space Complexity*: $O(1)$ auxiliary.
- **Quick Sort**:
  - A divide-and-conquer algorithm. It picks an element as a pivot and partitions the array around the pivot, placing smaller elements before and larger elements after it. Then, it recursively sorts the sub-arrays.
  - *Time Complexity*: $O(N \log N)$ average-case; $O(N^2)$ worst-case (if pivot selection is poor on pre-sorted data).
  - *Space Complexity*: $O(\log N)$ auxiliary due to call stack.
- **Merge Sort**:
  - A divide-and-conquer algorithm. It divides the array in half, recursively sorts each half, and then merges the sorted halves.
  - *Time Complexity*: $O(N \log N)$ in all cases (best, average, worst).
  - *Space Complexity*: $O(N)$ auxiliary (requires copying data).

---

## 2. Bubble Sort vs. Quick Sort Comparison

| Metric | Bubble Sort | Quick Sort |
|---|---|---|
| **Average Time Complexity** | $O(N^2)$ | $O(N \log N)$ |
| **Worst-case Time Complexity**| $O(N^2)$ | $O(N^2)$ |
| **Best-case Time Complexity** | $O(N)$ (with swap flag) | $O(N \log N)$ |
| **Space Complexity** | $O(1)$ | $O(\log N)$ |
| **Stability** | Stable | Unstable |
| **Practical Speed** | Very Slow | Very Fast |

---

## 3. Why Quick Sort is Preferred Over Bubble Sort

1. **Massive Performance Difference at Scale**: As $N$ grows, the difference between $N^2$ and $N \log N$ grows exponentially. For example, for $N = 100,000$ elements:
   - Bubble Sort takes up to $10,000,000,000$ comparisons.
   - Quick Sort takes $\approx 100,000 \times 17 \approx 1,700,000$ comparisons.
2. **In-place Sorting**: Unlike Merge Sort, Quick Sort does not require $O(N)$ additional memory, making it highly memory-efficient.
3. **Cache Friendliness**: Quick Sort displays excellent locality of reference, which makes it perform significantly better on physical CPU caches than other sorting algorithms.

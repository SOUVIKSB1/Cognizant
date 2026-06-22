# Exercise 2: E-commerce Platform Search Function

## 1. Understanding Asymptotic Notation

### Big O Notation
Big O notation is a mathematical notation used in computer science to describe the upper bound of the execution time or space complexity of an algorithm relative to the size of the input (denoted as $N$). 
- It helps developers evaluate how an algorithm will perform as the input size scales up to infinity, stripping away hardware or compiler-dependent constant factors.
- By looking at the growth rate, we can choose the most appropriate algorithm for large datasets.

### Search Operation Scenarios
- **Best-case**: The scenario where the target element is found in the minimum possible steps. For both Linear and Binary search, this is $O(1)$ (e.g., target is at the first element we check).
- **Average-case**: The expected behavior over typical random distributions of queries. 
- **Worst-case**: The maximum number of operations required (e.g., target is at the very end of the search space, or is not present at all).

---

## 2. Linear Search vs. Binary Search Comparison

| Feature | Linear Search | Binary Search |
|---|---|---|
| **Data Requirements** | None (can be unsorted) | Data **must be sorted** |
| **Best-case Time** | $O(1)$ | $O(1)$ |
| **Average-case Time**| $O(N)$ | $O(\log N)$ |
| **Worst-case Time** | $O(N)$ | $O(\log N)$ |
| **Space Complexity** | $O(1)$ | $O(1)$ |
| **Algorithmic Strategy**| Sequential Scanning | Divide and Conquer |

---

## 3. Platform Suitability Discussion

For an e-commerce platform, **Binary Search** (or hybrid search indices like B-Trees/inverted index tables) is much more suitable:
1. **Search Scaling**: E-commerce platforms scale up to millions of items. An $O(N)$ linear search scanning millions of elements per request would cripple the servers.
2. **Efficiency**: With $1,000,000$ products, Linear Search takes up to $1,000,000$ comparisons. Binary Search takes at most $\approx \log_2(1,000,000) \approx 20$ comparisons.
3. **Sorting Overhead**: While binary search requires sorting ($O(N \log N)$), products are updated far less frequently than they are searched. Therefore, the sorting cost is amortized over thousands of rapid lookup queries.

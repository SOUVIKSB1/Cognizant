# Exercise 1: Inventory Management System

## 1. Understanding the Problem
### Why Data Structures and Algorithms are Essential
In a warehouse setting, the inventory can easily scale to hundreds of thousands or millions of products. Using inefficient data storage or search mechanisms (like flat-file listings or linear arrays scanned sequentially) would result in unacceptable delays when trying to retrieve, modify, or add items. 
- **Efficiency**: Proper structures minimize CPU cycles and memory usage.
- **Scalability**: A logarithmic or constant-time algorithm scales smoothly as inventory grows, whereas a linear algorithm slows down drastically.
- **Concurrency**: Large warehouses require multiple queries simultaneously. Optimized structures prevent bottlenecks and race conditions.

### Suitable Data Structures
1. **ArrayList / List**:
   - *Pros*: Memory-efficient, fast traversal, quick access by index if index is known.
   - *Cons*: Adding or deleting items requires shifting elements ($O(N)$), and searching for a product by ID requires scanning the entire list ($O(N)$).
2. **HashMap / Dictionary**:
   - *Pros*: Provides average $O(1)$ constant time complexity for key-based lookups, insertions, and deletions.
   - *Cons*: Higher memory overhead due to hash tables, unordered keys.
3. **Self-Balancing Binary Search Trees (e.g., Red-Black Tree, SortedDictionary in C#)**:
   - *Pros*: Keeps products sorted by key; lookup, insertion, and deletion are $O(\log N)$.
   - *Cons*: Marginally slower than $O(1)$ dictionary lookups.

---

## 2. Implementation Choice
We chose a **`Dictionary<string, Product>`** (HashMap equivalent in C#) for our inventory representation. The `ProductId` serves as the unique key, and the `Product` object is the value.

---

## 3. Analysis of Operations in chosen data structure (`Dictionary`)

| Operation | Time Complexity (Average) | Time Complexity (Worst Case) | Space Complexity |
|---|---|---|---|
| **Add** | $O(1)$ | $O(N)$ (if resizing or hash collision occurs) | $O(1)$ |
| **Update** | $O(1)$ | $O(N)$ (hash collision search) | $O(1)$ |
| **Delete** | $O(1)$ | $O(N)$ (hash collision search) | $O(1)$ |
| **Search/Get** | $O(1)$ | $O(N)$ | $O(1)$ |

*Note: The worst-case $O(N)$ occurs if all keys hash to the same bucket (hash collision), but modern hashing algorithms and resizing strategies make this extremely rare, ensuring close to $O(1)$ in practice.*

---

## 4. Optimization Discussion
- **Initial Capacity**: If the approximate number of products is known beforehand, we should initialize the Dictionary with an initial capacity. This prevents runtime re-hashing and memory re-allocations.
- **Concurrent Access**: In multi-threaded environments, we can replace `Dictionary` with `ConcurrentDictionary` to ensure thread safety without manual locking overhead.
- **Hashing Function**: Ensure the unique key (`ProductId`) has a good hash distribution function to prevent collisions.

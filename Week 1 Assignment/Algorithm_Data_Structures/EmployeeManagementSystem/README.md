# Exercise 4: Employee Management System

## 1. Understanding Array Representation

### Array Memory Representation
An array is a collection of elements of the same type stored in contiguous memory locations. When an array is allocated:
1. The system reserves a single contiguous block of memory sufficient to hold the maximum size specified.
2. The memory address of the first element is known as the **Base Address**.
3. The address of any element at index `i` is calculated using a simple offset formula:
   $$\text{Address}(A[i]) = \text{Base Address} + i \times \text{Size of element}$$
4. This mathematical formula allows for **$O(1)$ constant-time random access** to any index.

### Advantages of Arrays
- **Fast Random Access**: Direct lookup by index is instantaneous.
- **Cache Locality**: Stored contiguously, adjacent elements are loaded into CPU cache lines together, yielding superior performance during sequential iterations.
- **Memory Efficiency**: Minimal metadata overhead compared to Node-based structures.

---

## 2. Time Complexity Analysis

| Operation | Time Complexity (Best Case) | Time Complexity (Worst Case) | Time Complexity (Average Case) | Description |
|---|---|---|---|---|
| **Add** | $O(1)$ | $O(1)$ | $O(1)$ | Adding at the end of a non-full array requires no shifting. |
| **Search** | $O(1)$ | $O(N)$ | $O(N)$ | Linear search by ID; best case is if it's the first element. |
| **Traverse** | $O(N)$ | $O(N)$ | $O(N)$ | Must visit all $count$ elements. |
| **Delete** | $O(1)$ | $O(N)$ | $O(N)$ | Deletion of the last element is $O(1)$; deleting the first element requires shifting all remaining elements to the left ($O(N)$). |

---

## 3. Limitations of Arrays and When to Use Them

### Limitations
- **Fixed Size**: Once allocated, the capacity cannot be changed. Resizing requires allocating a new, larger array and copying all elements ($O(N)$).
- **Expensive Insertions/Deletions**: Shifting elements to maintain contiguous memory is costly.
- **Memory Wastage**: If an array is initialized to a large size but rarely filled, the unused space remains allocated.

### When to Use
- When the maximum number of items is known beforehand.
- When random access (lookup by numerical index) is the primary operation.
- When memory space is tight and element iteration speed (cache locality) is critical.

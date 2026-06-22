# Exercise 7: Financial Forecasting

## 1. Understanding Recursive Algorithms

### Concept of Recursion
Recursion is a programming technique where a method solves a problem by calling itself one or more times with simpler sub-problems until it reaches a terminal condition, known as the **Base Case**.
- **Base Case**: The condition under which the function stops calling itself and returns a value.
- **Recursive Case**: The part where the function calls itself with a modified input that moves closer to the base case.

### How Recursion Simplifies Problems
Recursion naturally models problems that exhibit a self-similar hierarchical structure (e.g., directory structures, tree traversals, fractal calculations, and inductive mathematical series like Fibonacci, factorials, and compound interest progression). It makes the code cleaner, more readable, and closer to mathematical definitions.

---

## 2. Time Complexity Analysis

For our recursive future value calculation:
- **Recurrence Relation**: $T(n) = T(n-1) + O(1)$, where $n$ is the number of periods (years).
- **Time Complexity**: **$O(n)$** because there are exactly $n$ recursive method invocations.
- **Space Complexity**: **$O(n)$** because each recursive call adds a stack frame to the system call stack. If $n$ is very large (e.g., $100,000$), this can lead to a `StackOverflowException`.

---

## 3. How to Optimize the Solution

To avoid excessive CPU computation, call overhead, and stack usage:
1. **Iteration**: Replace recursion with a simple `for` or `while` loop. This reduces space complexity from $O(n)$ to $O(1)$ while keeping the time complexity at $O(n)$, completely eliminating the stack overflow risk.
2. **Memoization (Dynamic Programming)**: Store the result of sub-problems in a lookup table (e.g., array or dictionary). In single-branch recursion (like this future value calculation), memoization is not strictly needed since there are no redundant overlapping sub-problems (unlike Fibonacci). However, for multi-branch recursion (e.g., $T(n) = T(n-1) + T(n-2)$), memoization optimizes the time complexity from $O(2^n)$ to $O(n)$.
3. **Tail Recursion Optimization (TCO)**: In compilers that support TCO, writing the recursive call as the absolute last statement in the method allows the compiler to reuse the current stack frame, reducing space complexity to $O(1)$. C# and the .NET JIT compiler do not guarantee tail-call optimization in all configurations, making iteration the safest choice.

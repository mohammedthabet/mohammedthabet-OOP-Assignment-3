# Collections — Answers

## Task 2.1 — Research

### IReadOnlyDictionary<TKey, TValue>

`IReadOnlyDictionary<TKey, TValue>` is a read-only interface for a collection of key/value pairs. It allows the caller to read values by key, check whether a key exists, and enumerate the keys and values, but it does not expose operations such as Add, Remove, or Clear.

A `Dictionary<TKey, TValue>` can be modified by its caller, while an `IReadOnlyDictionary<TKey, TValue>` reference only exposes read operations. A public method can return `IReadOnlyDictionary` when callers need to inspect the data but should not be able to modify the collection through the returned API.

This does not necessarily mean that the underlying collection is immutable. The object behind the interface may still be modified by the code that owns it.

### SortedDictionary<TKey, TValue>

`SortedDictionary<TKey, TValue>` stores key/value pairs and keeps them sorted by key.

Unlike a normal `Dictionary<TKey, TValue>`, its enumeration follows key order. A normal Dictionary is optimized for fast hash-based lookup, while a SortedDictionary uses a tree and has O(log n) lookup.

I would choose a `SortedDictionary` when I need key/value lookup and also need the collection to remain sorted by key as items are added or removed.

## Task 2.2 — Pick the Collection

### S1 — Find a student by national ID thousands of times a day
**Dictionary**

A `Dictionary` is a good choice because it provides fast lookup by a unique key such as the national ID.

### S2 — Keep course tags without duplicates
**HashSet**

A `HashSet` is designed for unique values and prevents the same tag from being stored more than once.

### S3 — Keep grades in insertion order and allow duplicates
**List**

A `List` keeps items in sequence and allows duplicate grades.

### S4 — Return a course price list that callers can read but not modify
**IReadOnlyDictionary**

An `IReadOnlyDictionary` exposes key/value lookup to callers without exposing methods for adding, removing, or changing entries.

### S5 — Timetable keyed by start time and always printed in time order
**SortedDictionary**

A `SortedDictionary` keeps its entries sorted by key, so using the session start time as the key keeps the timetable in time order.

### S6 — Results are only enumerated once and the caller may stop early
**IEnumerable**

`IEnumerable` allows results to be consumed sequentially and can support lazy execution, so work can stop when the caller stops enumerating.
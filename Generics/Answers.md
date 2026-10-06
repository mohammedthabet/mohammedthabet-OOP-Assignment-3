# Generics — Answers

## Step 2

### What is the same between the two stores?

Both `StudentStore` and `CourseStore` use a `List` to store items and implement the same four operations: `Add`, `GetById`, `GetAll`, and `Remove`. Both also search for an item by its `Id`.

### What is different?

The main difference is the type they store. `StudentStore` works with `Student` objects, while `CourseStore` works with `Course` objects. The entity classes also contain different properties besides their common `Id`.

## Step 3

### Compiler error

`error CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found.`

### Why does the compiler reject it?

`Store<T>` can currently accept any type as `T`. The compiler therefore cannot assume that every possible type has an `Id` property. When the code tries to access `item.Id`, there is no constraint or contract telling the compiler that `T` must provide an `Id`.

## Step 7

### Why does Store<string> not compile?

`Store<T>` has the constraint `where T : IHasId`. This means that any type used with `Store<T>` must implement `IHasId`.

`Student` and `Course` implement `IHasId`, so they can be used with the store. `string` does not implement `IHasId`, so `Store<string>` is rejected by the compiler.

## Final Research Question

The common name for the kind of class built in Steps 4 and 5 is a **generic repository**.

It provides a reusable abstraction for storing and retrieving different entity types while using a common contract such as `IHasId`.
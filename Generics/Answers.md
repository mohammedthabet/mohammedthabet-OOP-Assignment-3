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
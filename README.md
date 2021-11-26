# CSharp.Core
A library containing static methods for performing tasks in a simpler and cleaner way.

### Basic methods
The following are the basic methods which demonstrate the use as well as the comparison between the new method vs traditional methods. The first part of the code will be the new method and the second part will be the traditional way.

#### Print method
Writes a line on console which is equivalent to writing `Console.WriteLine`.
```
// New way
Print("Print something on the console");

// Old way
Console.WriteLine("Print something on the console");
```

#### Is method
This method executes an action only if the condition is true.
```
string name = "somename";

// New way
Is(name == "somename", () => Print("Your comparison returned true, so am executing this code..."));

// Old way
if (name == "somename") {
  Console.WriteLine("Your comparison returned true, so am executing this code...")
}
```
---
#### IsNot method
This method executes an action only if the condition is false.
```
string name = "somename";

// New way
IsNot(name == "othername", () => Print("Execute this code..."));

// Old way
if (name != "othername") {
  Console.WriteLine("Execute this code...")
}
```
---
#### Loop method
This method iterates between a given from and to range and executes the desired action.
```
// New way - Printing Line number with 2 steps iteration
Loop(1, 100, (i) => c.Print($"Line {i}"), 2);

//Old way - Printing Line number with 2 steps iteration
for(int i = 1, i<=100; i+=2) {
  Console.WriteLine($"Line {i}");
}

// New way
Loop(5, 1, (i) => c.Print($"Line {i}"));

//Old way
for(int i = 5, i>=1; i--) {
  Console.WriteLine($"Line {i}");
}
```
---
#### RandomNumber method
This method outputs a random number between given two numbers.
```
// New way
int number = RandomNumber(1, 10);

// Old way
int number = new Random.Next(1, 10);
```
---
#### IsNull method
This method executes an action only if the instance is null.
```
string name = null;

// New way
IsNull<string>(name, () => Print($"Is null ..."));

// Old way
if (name == null) {
  Console.WriteLine($"Is null ...");
}
```
---
#### IsNotNull method
This method executes an action only if the instance is not null.
```
string address = "Address";

// New way
IsNotNull(address, (address) => Print($"Is not null ..."));

// Old way
if (address != null) {
  Console.WriteLine($"Is not null ...");
}
```

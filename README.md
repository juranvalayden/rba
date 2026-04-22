# RBA
An implementation of the **Martian Robots** problem, following the provided specification.

---

## Planning – Thought Process & Assumptions

### Grid Data (Line 1)
**Business Rules & Validations**
- Space-separated values  
- Maximum length: 3 tokens  
- Index 0 and 2 must be integers  
- Grid must be rectangular → `X != Y`

### Robot Data Sets (Lines 2–4)
**Line 2**  
- Sections off single grid data for subsequent `RobotDataSet(s)`

**Line 3 – Starting Block / Initial Position**
- Space-separated values  
- Maximum length: 5 tokens  
- Index 0 and 2 must be integers  
- Index 4 must contain a single character/string representing a cardinal direction: `N`, `E`, `W`, `S` (extensible)

**Line 4 – Instructions**
- String input, maximum length: 100 characters  
- Must only contain `R`, `L`, and `F`

**Line 5**  
- Blank line
- Sections off `RobotDataSet`
- Lines 3, 4, 5 loop until the end of file

---

## Project & Implementation

The solution is built on **.NET 10** and uses the following NuGet packages:

| NuGet Package               | Version |
|-----------------------------|---------|
| Microsoft.NET.Test.Sdk      | 17.14.1 |
| coverlet.collector          | 6.0.4   |
| Moq                         | 4.20.72 |
| xunit                       | 2.9.3   |
| xunit.runner.visualstudio   | 3.1.4   |

### Notes
- I thoroughly enjoyed this coding challenge and hope you enjoy reviewing it.  
- Since the UI was not the focus, I implemented the solution as a **test suite**.  
- Initially, I considered a console application with file-reading loops, but opted against it for simplicity.  
- A full clean-architecture implementation was also considered, but deemed overkill for the scope.  
- All code resides in the test suite for straightforward execution.  
- To run, simply clone the project, build and run tests.

---

## Running the Tests

Use the terminal to execute:

```sh
dotnet test <path_to_project>
# RBA
An implementation of the "Martian Robots" following the spec documentation provided

---

## Planning - Thought Process & Assumptions

#### Line 1
Grid Data 
1. Business Rules and Validations
1.1. Space separated
1.1. Max length of 3
1.1. index 0, 2 - Only ints are valid
1.1. Since it is mentioned that the grid is rectangular | X != Y

#### Line 2
Sections single grid data for the following "RobotDataSet(s)"

#### Line 3 & 4
Robot Data Sets
1. Business Rules and Validations
1.1. Starting block or initial position for robot
1.1. Line 3
1.1.1. Space separated
1.1.1. Max length of 5
1.1.1. index 0, 2 - Only ints are valid
1.1.1. index 4 - Only contain a single "char/string" value which signifies a cardinal N, E, W, S (for now, this can be extended)
1.1. Line 4
1.1.1. String and should not exceed 100 chars
1.1.1. Should only contain "R", "L" and "F"

---

## About the Project and Implementation

The solution is built on .net10 and uses the following nuget packages, in order to run:
| Nuget Package | Version |
| coverlet.collector | 6.0.4 |
| Microsoft.NET.Test.Sdk | 17.14.1 |
| Moq | 4.20.72 |
| xunit | 2.9.3 |
| xunit.runner.visualstudio | 3.1.4|

- Since it is mentioned that the UI should not be the focus, I went with simply using a test suite.
- I was inclined to create a console application which followed a simple looping mechanism to allow files to be read however I moved away from that idea.
- I was also going to have the solution implemented in full clean-architecture but it may have been overkill hence you will see it that all the code has been moved to test suite. 

You may simply clone the project and run the test suite

Use the terminal to execute 

* cmd
  ```sh
  dotnet test <path_to_project>
  ```

  - I thoroughly enjoyed the coding challenge and hope that you enjoyed reviewing it :)
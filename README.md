# toy-robot

**Requirements**

1. *Table to place robot* 5x5


04|14|24|34|44

03|13|23|33|43

02|12|22|32|42

01|11|21|31|41

00|10|20|30|40

2. Rotate Robot LEFT | RIGHT
3. Can't Move robot out of the table
-------------------

How do I implement
- Provide CommandInvoker.cs that going to handle all commands we would like to compute
 FYI: The end of command input is "REPORT"
- I've implemented 4 commands
  - PlaceCommand
  - MoveCommand
  - RotateCommand
  - ReportCommand
- The Robot direction
  - NORTH = 0
  - EAST = 1
  - SOUTH = 2
  - WEST = 3
- If you rotate the robot 
  - LEFT = current direction - 1 
  - RIGHT = current direction - 1 
  
  for example 
  - if *NORTH* rotate to *LEFT* = 0-1 = -1
	then return facing = *WEST*
	    
  
  
  

  




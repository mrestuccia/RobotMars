# Robots Mars
OOP coding exersice

# List of Assumptions
1. Robots can be on the same space of the matrix.
2. Instructions are been read from a .txt file that should be called input.txt and it's located in the input folder
3. Output is been displayed in the console.
4. Robots execute in sequence.


# About the code
- 2 main classes Robot and World.
- 2 class mappers. This translated the input into the Object instances.
- One main class and one helper for reading the file and splitting the initial lines.

The idea was to create 2 classes that represent the problem. One to the robot and the other the world (context).

The context is been created separated from the robots. Allowing to have several robots, but only one world. The current state of the world is been passed to the robot when the robot execute the instructions (commands).

Additionally 2 class mappers has been created. This deal with ensuring that the input that is comming is valid enought to create the main classes. Validations are performed here and not in the main classes (more abstract).

The file program acts as main controller. Loading the instructions from the file and passing it to the mappers. If mappers accepts and create the classes, the robots execute the commands.


# Pending
- More Unit Testing.
- The main example provided should be added as the main test case.
- The queue scent is saving many instances of the same scent. It should be only one.

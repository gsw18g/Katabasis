Software Requirements and Design 
Document 
For
Group <8>
Version 1.0
Authors: 
Alejandro S
Gavin W
Kaitlin T
Lloyd S
Matthew K
1. Overview (5 points) Give a general overview of the system in 1-2 paragraphs (similar to the one in the project 
proposal). 
- Katabasis is an action platformer based on the Greek myth of Orpheus and Eurydice. The game will be developed using Unity’s game engine and will feature 5 levels, with a miniboss at the end of each one. Unable to come to terms with the death of his wife, Orpheus enters the underworld with the hopes of bringing Eurydice back to the land of the living, weapons and Lyre in hand. However, Hades has no intentions of allowing Orpheus to cheat death. Like the original story, the game will end in tragedy.
2. Functional Requirements (10 points)List the functional requirements in sentences identified by numbers and for each requirement 
state if it is of high, medium, or low priority. Each functional requirement is something that the 
system shall do. Include all the details required such that there can be no misinterpretations of 
the requirements when read. Be very specific about what the system needs to do (not how, just 
what). You may provide a brief design rationale for any requirement which you feel requires 
explanation for how and/or why the requirement was derived.

1. A high priority is for the player’s character to be able to move by pressing A(left) and D(right).
2. A high priority is for the player to be able to jump while on the ground.
3. A high priority is for screen to display the player’s current health value and deduct health when attacked by enemies.
4. A high priority is for the player to be able to attack the enemies by pressing the Left Mouse Button.
5. A medium priority is for the player to have several attacks available, including but not limited to a sword stab attack, a sword horizontal attack, a sword vertical attack, and a ranged bow and arrow attack. The stab attack shall deal the least damage, the horizontal attack medium damage, and the vertical attack high damage. 
6. A high priority is to implement several enemy types including but not limited to a flying bat, a melee zombie, and a ranged enemy.
6. A medium priority is to implement a knockback to the player when attacked by an enemy.
7. A medium priority is to implement a knockback when attacking an enemy.
8. A high priority is to allow the player’s character as well as the enemies to walk on a sloped surface.
9. A medium priority is to implement bobbing platforms over water which sink when the player walks on them.
10. A high priority is to have a boss fight at the end of all levels.
11. A medium priority is to have 5 playable levels plus an introduction level.


3. Non-functional Requirements (10 points)List the non-functional requirements of the system (any requirement referring to a property of 
the system, such as security, safety, software quality, performance, reliability, etc.) You may 
provide a brief rationale for any requirement which you feel requires explanation as to how and/or 
why the requirement was derived.
4. Use Case Diagram (10 points)This section presents the use case diagram and the textual descriptions of the use cases for 
the system under development. The use case diagram should contain all the use cases and 
relationships between them needed to describe the functionality to be developed. If you discover 
new use cases between two increments, update the diagram for your future increments. 
Textual descriptions of use cases: For the first increment, the textual descriptions for the use 
cases are not required. However, the textual descriptions for all use cases discovered for your 
system are required for the second and third iterations.
5. Class Diagram and/or Sequence Diagrams (15 points)This section presents a high-level overview of the anticipated system architecture using a class 
diagram and/or sequence diagrams. 
If the main paradigm used in your project is Object Oriented (i.e., you have classes or 
something that acts similar to classes in your system), then draw the Class Diagram of the 
entire system and Sequence Diagrams for the three (3) most important use cases in your 
system. 
If the main paradigm in your system is not Object Oriented (i.e., you do not have classes or 
anything similar to classes in your system) then only draw Sequence Diagrams, but for all the 
use cases of your system. In this case, we will use a modified version of Sequence Diagrams, 
where instead of objects, the lifelines will represent the functions in the system involved in the 
action sequence. 
Class Diagrams show the fundamental objects/classes that must be modeled with the system 
to satisfy its requirements and the relationships between them. Each class rectangle on the 
diagram must also include the attributes and the methods of the class (they can be refined 
between increments).  All the relationships between classes and their multiplicity must be 
shown on the class diagram. 
A Sequence Diagram simply depicts interaction between objects (or functions - in our case - 
for non-OOP systems) in a sequential order, i.e. the order in which these interactions take place. 
Sequence diagrams describe how and in what order the objects in a system function. 
6. Operating Environment (5 points)Describe the environment in which the software will operate, including the hardware platform, 
operating system and versions, and any other software components or applications with which it 
must peacefully coexist.
7. Assumptions and Dependencies (5 points)List any assumed factors (as opposed to known facts) that could affect the requirements stated in 
this document. These could include third-party or commercial components that you plan to use, 
issues around the development or operating environment, or constraints. The project could be 
affected if these assumptions are incorrect, are not shared, or change. Also identify any 
dependencies the project has on external factors, such as software components that you intend 
to reuse from another project.

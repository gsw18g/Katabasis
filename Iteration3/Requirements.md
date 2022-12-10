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
1. Overview (5 points)
- Katabasis is an action platformer based on the Greek myth of Orpheus and Eurydice. The game will be developed using Unity’s game engine and will feature 5 levels, with a miniboss at the end of each one. Unable to come to terms with the death of his wife, Orpheus enters the underworld with the hopes of bringing Eurydice back to the land of the living, weapons and Lyre in hand. However, Hades has no intentions of allowing Orpheus to cheat death. Like the original story, the game will end in tragedy.
2. Functional Requirements (10 points)
    1. A high priority is for the player’s character to be able to move by pressing A(left) and D(right).
    2. A high priority is for the player to be able to jump while on the ground.
    3. A high priority is for screen to display the player’s current health value and deduct health when attacked by enemies.
    4. A high priority is for the player to be able to attack the enemies by pressing the Left Mouse Button.
    5. A medium priority is for the player to have several attacks available, including but not limited to a sword stab attack, a sword horizontal attack, a sword vertical attack, and a ranged bow and arrow attack. The stab attack shall deal the least damage, the horizontal attack medium damage, and the vertical attack high damage. 
    6. A high priority is to implement several enemy types including but not limited to a flying bat, a melee zombie, and a ranged enemy.
    6. A medium priority is to implement a knockback to the player when attacked by an enemy.
    7. A medium priority is to implement a knockback when attacking an enemy.
    8. A high priority is to allow the player’s character as well as the enemies to walk on a sloped surface.
    9. A high priority is to allow the player to jump on a sloped surface.
    10. A medium priority is to implement bobbing platforms over water which sink when the player walks on them.
    11. A high priority is to have a boss fight at the end of all levels.
    12. A medium priority is to have 5 playable levels plus an introduction level.
    13. A medium priority is to implement charon's boat which carries the player as it moves towards the end of the level.
    14. A medium priority is to add an attack pattern to the bat enemy
    15. A medium priority is to use the sloped surfaces to make hills so that the levels aren't just flat platforms.
    16. A medium priority is to create platforms that the player and enemies can walk on.
    17. A medium priority is to create zombies that crawl out of the ground.
    18. A medium priority is to add a cerberus semi boss.
    19. A medium priority is to implement cut scenes at the beginning of the game.
    20. A high priority is to implement a death screen with navigation menu, including Continue, Restart, Main Menu, and Quit buttons.
    21. A high priority is to have the player be taken to level 2 after completing level 1 automatically.
    22. A high priority is to have zombies that patrol back and forth until the player gets close and then they attack.
    23. A high priority is to have zombies that have health bars that reflect their current health, and health gets deducted when they are attacked.
    24. A high priority is to implement the river styx that kills the player if they fall into it.
    25. A high priority is to start moving charon's boat when the player reaches a certain point, and stops at a certain point.
    26. A high priority is to 

3. Non-functional Requirements (10 points)
    1. The user must experience a satisfying story through the levels.
    2. The user must experience a smooth interaction between their input and the game output.
    3. The user must feel challenged.
    4. The game must have different levels of difficulty.
    5. The game must have a unique atmosphere that correlates with the story.
    6. The game must have a satisfying fight system.
    7. The game must run smoothly from scene to scene.
    8. The minimum frame rate must be 30 frames per second.
    9. The average response time between user input and reaction must be less than 0.5 seconds.
    10. The code written for the game must be maintainable and organized.
    11. There must be sufficient documentation to improves maintainability as the scale of the game increases.

4. Use Case Diagram (10 points)
- ![Use Case Diagram](/Iteration1/CaseDiagram.png)

5. Class Diagram and/or Sequence Diagrams (15 points)
- ![Class Diagram](/Iteration2/Diagram.pdf)

6. Operating Environment (5 points)
- Katabasis aims to run on almost any modern computer as it is a simple game that doesn't consume many resources. It's being developed on Unity 2021.3.11f1 and will require components of this software in order to run.

7. Assumptions and Dependencies (5 points)

- For this game we plan to use assets found in the Unity store to improve the environment and atmosphere of our game. We assume the game will be deployed on a computer with sufficient RAM and computing power to run the game. We are dependent on the Unity framework, more importantly the 2021.3.11f1 editor version. Any changes made to the project outside of this version can cause complications.

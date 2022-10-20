**Progress Report**
*- Increment 1 -*
Group #8

1) Team Members

- Alejandro Santiago
  - FSU ID: aes19k
  - GitHub ID: alexsan5

- Gavin Williams
  - FSU ID: gsw18g
  - GitHub ID: gsw18g

- Kaitlin Tran
  - FSU ID: kht19
  - GitHub ID: ktran41

- Lloyd Smith
  - FSU ID: las18g
  - GitHub ID: Wattomato

- Matthew Kaplan
  - FSU ID: mak03e
  - GitHub ID: tarkovguy2057

2) Project Title and Description
- Katabasis

  - Katabasis is an action platformer based on the Greek myth of Orpheus and Eurydice. The game will be developed using Unity’s game engine and will feature 5 levels, with a miniboss at the end of each one. Unable to come to terms with the death of his wife, Orpheus enters the underworld with the hopes of bringing Eurydice back to the land of the living, weapons and Lyre in hand. However, Hades has no intentions of allowing Orpheus to cheat death. Like the original story, the game will end in tragedy.
3) Accomplishments and overall project status during this increment 
Describe in detail what was accomplished during this increment and where your project stands 
overall compared to the initial scope and functionality proposed.

During increment 1 we accomplished several things including setting up our github repository and taking the first steps in order to make our platformer game. The first step was to create a moveable player character with walking, jumping, and attack animations. Next we created a zombie enemy, which has walking and death animations as well as a bat enemy with its own animation. Originally when the zombie enemy was attacked by the player, they got knocked back in the opposite direction of the attack and a floating health bar showed their damage. We had to remove this knockback feature for the moment because it was causing some issues, however the code is working. The player character also gets knocked back when attacked by enemies. There is a health system HUD (heads up display) which shows the player how much health is remaining in the form of three hearts in the upper left corner of the screen. Parallax scrolling backgrounds were created to give the illusion of depth when moving. We also implemented a system that allows the player and enemies to walk on sloped surfaces. Overall we have a good start on creating the mechanics and objects that we will use to begin building levels and boss fights for the rest of the game.



4) Challenges, changes in the plan and scope of the project and things that went wrong during this increment
- Unity editor related errors
  - Set up Github Desktop to push and pull directly from repo, but if someone pushed with a different editor than the main project then the entire game broke
  - Resorted to pushing separate files onto repo in separate folders unrelated to Unity project
- Walking on slope
  - Walking animation was only horizontal at first so walking on slope looked unnatural
  - Mostly resolved but can't jump while moving on slope
- Enemies
  - Attacking enemy deducts health from both player and enemy
  - Bat knockback on player not working because friction physics has to be on ground, eventually bats will attack player
  - Only can spawn one zombie, killing one zombie will kill all immediately
  - Zombies do not have idle state so they are always following player, will eventually have zombie pacing in one spot mindlessly until it "sees" player
- Parallax scrolling needs adjustments
  - Unsure what correct ratio is for speed between backgrounds, looks a little fast
- Scope of increment
  - Originally had plans to include a bossfight/chase scene with Cerberus but the main level obstacles had to be overcome first
  - First level was much more difficult to create than we expected, especially due to the learning curve
- Scope of project
  - Added tutorial level along with 5 levels as an easy first level to work on, once it is complete all we have to do is take generally applicable scripts and assets to apply to our own levels with unique designs
  - Gathering system, weapons, checkpoint put on back burner in favor of focusing playable game (only need one kind of attack and a basic health system to get through levels as of now)
  - Decided to remove double jump feature for the sake of simplicity in level design, but still keeping dash and wall stick which will make up for it
5) Team Member Contribution for this increment
Please list each individual member and their contributions to each of the deliverables in this increment (be as detailed as possible). In other words, describe the contribution of each team 
member to:

- Alejandro Santiago
  - Progress Report: Sections 5, 6
  - Requirements and Design Document: Section 5
  - Implementation and Testing Document: Section 2
  - Source Code
  - Video: General overview of project, video editing and uploading

- Gavin Williams
  - Progress Report: Section 5
  - Requirements and Design Document: Sections 3, 7
  - Implementation and Testing Document: N/A
  - Source Code
  - Video: Demo of current project, screen recording

- Kaitlin Tran
  - Progress Report: Sections 1, 2, 4, 5
  - Requirements and Design Document: Section 1
  - Implementation and Testing Document: Section 1
  - Source Code: Contributions included scripts involving character animation, scrolling camera movement, and boss fight/death scenes, as well as all character sprites. They can be found in the following folders:
    - Katabasis/Kaitlin/*
    - Katabasis/Assets/Sprites/bat/*
    - Katabasis/Assets/Sprites/hor swing/*
    - Katabasis/Assets/Sprites/orpheus/*
    - Katabasis/Assets/Sprites/zombie/*
  - Video: Describe any change in scope of project and explanation

- Lloyd Smith
  - Progress Report: Section 5
  - Requirements and Design Document: Sections 4, 6
  - Implementation and Testing Document: N/A
  - Source Code
  - Video: Plan for next increment

- Matthew Kaplan
  - Progress Report: Sections 3, 5
  - Requirements and Design Document: Section 2
  - Implementation and Testing Document: N/A
  - Source Code: 
      - Scripts for check_ground, enemy_melee, melee_enemy, title_screen, move_bat, move_camera, scroll parallaz foreground, midground, background,                                    player_health, player_movement, remove_heart, scale_enemy_healthbar, slope, spawn_zombie, sword, sword_check, sword_collider, zombie2 which can be
                 found in Katabasis/Assets/Scripts
       - background assests and edited static foreground objects which can be found in Katabasis/Assets/Sprites
       - prefabs which can be found in Katabasis/Assets/Objects/prefabs
       - animation controller and scripts for player and enemy animations cab be found in Katabasis/Assets/Sprites/orpheus and Katabasis/Assets/zombie
       - sloped surface system which allows player and enemies to walk on slopes
        
  - Video: Short description of state of project and accomplishments for this increment
  
6) Plans for the next increment
If this report if for the first or second increment, describe what are you planning to achieve in the 
next increment.
7) Link to video
Paste here the link to your video.

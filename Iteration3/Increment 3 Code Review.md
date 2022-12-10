**REVIEWED ALL CS CODE FOUND IN Katabasis/Assets/Scenes/**
- Should remove unused scenes or put them in a separate folder
- Are scenes capitalized? Should we use underscores?

**REVIEWED ALL CS CODE FOUND IN Katabasis/Assets/Scripts/**
- Suggested changes found in Katabasis/Kaitlin/proposed_scripts/*

**OVERALL NOTES:**
- Please put your name at the top of the file/section you wrote
- If i wrote the wrong author down please correct it in the file oops
- File naming conventions: capitals or underscores? We should pick one
- Comment naming conventions: beside, over, or under lines? Capitalized or not?
- Variable naming conventions: capitals or underscores? Should pick one
- Are we still using “old background move”?
- Is “unused” to be implemented or to be deleted? Should probably sort
- TO BE RENAMED
  - Menu Manager
    - Katabasis/Assets/Scripts/Menu Manager
      - Change to /menu_manager
  - Enemy melee files
    - Katabasis/Assets/Scripts/enemy/enemy_melee.cs
    - Katabasis/Assets/Scripts/enemy/melee_enemy.cs
  - Hades folders
    - Katabasis/Assets/Scripts/enemy/hades/
      - Should this be deleted?
    - Katabasis/Assets/Scripts/hades
- Biggest issues
  - Inconsistent/unclear naming of variables, files, folders
  - Commented out code
  - Whitespace

**/Menu Manager/SelectionArrow.cs authored by Gavin Williams**
- Design
Remove unused code comments in lines 7, 8, 38-39, 55
- Functionality
Being able to select menu buttons
- Naming
Using capitalization in variables consistently
- Comments
Comments good

**/Menu Manager/SelectionArrow.cs authored by Gavin Williams and Matthew Kaplan**
- Design
Remove unused code comments in lines 7, 8, 38-39, 55
- Functionality
Being able to select menu buttons
- Naming
Using capitalization in variables consistently
- Comments
Comments good

**/camera/camera_level2.cs authored by Matthew Kaplan**
- Design
Remove unused code comments in lines 19, 22, 29, 32, 34, 36
- Functionality
Centers and moves camera with player
- Naming
Using lowercase underscores in variables consistently
- Comments
Comments good
- Changes from Increment 2
Commented out line 31 and replaced with current line 31
For movement with player

**/camera/move_camera.cs authored by Matthew Kaplan**
- Design
Remove unused code comments in lines 19, 22, 29, 33, 35
This does the same thing as camera_level2 except one value is changed, is there a better way to implement?
- Functionality
Centers and moves camera with player
- Naming
Using lowercase underscores in variables consistently
- Comments
Comments ok
- Changes from Increment 2
NO CHANGES except for removing some whitespace

**/charon/charon.cs**
- Design
Should charon have its own separate folder?
- Functionality
Starts and stops boat movement
- Naming
Using lowercase underscores in variables consistently
- Comments
No comments

**/enemy/hades/hades.cs authored by Matthew Kaplan**
- Design
Remove or implement unused code comments in lines 25, 38, 79, 103, 111-130
- Functionality
Moves hades like a normal enemy to follow player
- Naming
Using capitalization in variables inconsistently (last_player_pos is exception)
- Comments
Comments good
- Changes from Increment 2
NO CHANGES

**/enemy/hades/horn.cs authored by Matthew Kaplan**
- Design
No unused code comments
- Functionality
Hades animation reaction to contact with player
- Naming
Naming consistent
- No useful comments
- Changes from Increment 2
NO CHANGES

**/enemy/BATbehavior.cs authored by Lloyd Smith**
- Design
Unused code comments in lines 102, 159
Extra space in lines 211-217
- Functionality
Bat behavior when it sees player and gets damaged
- Naming
Bat in all caps in file name?
Variable naming inconsistent between capitalization and underscores
- Comments
Comments ok
- Changes from Increment 2
Radius isn’t 5f anymore, not defined in file (function called from game)

**/enemy/Behaviour.cs authored by Matthew Kaplan**
- Design
No unused code comments
Remove space in lines 90-97
- Functionality
Bat enemy behavior to follow and “hit” player and check if bat has been hit by player
- Naming
File named with capitalization
Why is it british spelling
Using capitalization and underscores in variables - inconsistent
Might want to rename to specify this is bat behavior
- Comments
Comments good
- Changes from Increment 2
NO CHANGES

**/enemy/EnemyDamage.cs authored by Gavin Williams**
- Design
No unused code comments
Looks for collisions with player
- Functionality
Give player “damage”
- Naming
File named with capitalization
Using lowercase underscores in variables consistently
- Comments
No comments
- Changes from Increment 2
NO CHANGES

**/enemy/EnemyPatrol.cs authored by Gavin Williams**
- Design
No unused code comments
- Functionality
Idle enemy patrolling movement
- Naming
File named with capitalization
Using capitalization in variables consistently
- Comments
No comments for anything except MoveInDirection function
- Changes from Increment 2
NO CHANGES

**/enemy/EnemyProjectile.cs authored by Gavin Williams**
- Design
Delete unused code comments in line 39
- Functionality
Activates, moves, and deactivates arrow when it hits an object
- Naming
File named with capitalization
Using capitalization in variables consistently
- Comments
Needs more comments, more than just line 54
- Changes from Increment 2
NO CHANGES

**/enemy/Health.cs authored by Gavin Williams**
- Design
No unused code comments
- Functionality
Is this for player health or enemy health?
- Naming
File named with capitalization
Using capitalization in variables consistently
Should rename the file or add comments to show what object this is affecting… unless this is for both player and enemies?
- Comments
No comments except for line 43
- Changes from Increment 2
NO CHANGES

**/enemy/ProjectileHolder.cs authored by Gavin Williams and Matthew Kaplan**
- Design
No unused code comments
Can we put this somewhere else or does it have to be in this file if it’s just one function?
- Functionality
This holds one function to update the projectile holder
- Naming
File named with capitalization
Using capitalization in variables consistently
- Comments
No comments
- Changes from Increment 2
NO CHANGES

**/enemy/RangedEnemy.cs authored by Gavin Williams and Matthew Kaplan**
- Design
Delete unused code comments in line 103
- Functionality
Ranged enemy behavior when it sees player and takes damage
- Naming
File named with capitalization
Using capitalization in variables inconsistently (take_damage vs cooldownTimer)
Function naming inconsistent (enemy_damage vs PlayerInSight)
- Comments
Comments ok
- Changes from Increment 2
NO CHANGES

**/enemy/SirenBeh.cs authored by Lloyd Smith**
- Design
No unused code comments
- Functionality
Siren enemy behavior
- Naming
File named with capitalization
Using capitalization in variables consistently
Names like plmv and Beh might get confusing
- Comments
No comments

**/enemy/destroy_dead_zombie.cs authored by Matthew Kaplan**
- Design
All this file does is call the Destroy(gameObject) function, can this be put somewhere else?
- Functionality
Destroys zombie object when it’s dead
- Naming
File named with underscores
Using lowercase underscores consistently
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/enemy/enemy_melee.cs authored by Gavin Williams and Matthew Kaplan**
- Design
Destroy(gameObject) function is called multiple times
Delete unused code comments in lines 74
- Functionality
Zombie behavior when it sees player and takes damage
- Naming
File named with underscores
Using lowercase consistently, underscores inconsistently
- Comments
Comments ok
- Changes from Increment 2
Float speed made public
New bool awake and functions to activate zombie
New bool stop_awake to deactivate zombie in some functions

**/enemy/fireball.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 23, 36, 38
- Functionality
Moves fireball obstacle
- Naming
File named with underscores
Using lowercase and underscores consistently
- Comments
Comments ok

**/enemy/fireball_destroy.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 36-49
Can this be combined with fireball.cs
- Functionality
Moves fireball obstacle, stops/destroys fireball after time period or if collision detected
- Naming
File named with underscores
Using lowercase and underscores consistently
- Comments
No comments

**/enemy/melee_enemy.cs authored by Gavin Williams and Matthew Kaplan**
- Design
Delete unused code comments in lines 23, 24
All this file does is define, get and set health can this be somewhere else?
- Functionality
Gets and sets health of enemy?
- Naming
File named with underscores
Confusing naming. One is enemy_melee the other is melee_enemy
Consistent variable names
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/enemy/move_bat.cs authored by Gavin Williams**
- Design
No unused code comments
Should this be in the file with the other bat behavior?
- Functionality
Moves bat enemy object
- Naming
File named with underscores
Consistent variable naming
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/enemy/scale_enemy_healthbar.cs authored by Gavin Williams**
- Design
Delete unused code comments in lines 19, 27
- Functionality
Scales enemy health bar display
- Naming
File named with underscores
Variable naming consistent
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/enemy/spawn_zombie.cs authored by Matthew Kaplan**
- Design
No unused code comments
- Functionality
Instantiate zombie object when scene starts
- Naming
File named with underscores
Consistent variable naming
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/enemy/zombie2.cs authored by Gavin Williams**
- Design
All code is commented out
- Functionality
This file doesn’t do anything, Delete or implement asap
- Naming
Why does this file name not have underscores?
Consistent variable naming with underscores
- Comments
No comments
- Changes from Increment 2
NO CHANGES

**/enemy/zombie_patrol.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 41, 95
- Functionality
Zombie idle patrol
- Naming
Inconsistent variable naming with capitalization, underscores
- Comments
Comments ok

**/environment/sink_check.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 27, 37
- Functionality
Sink platform if collision with player detected?
- Naming
File named with underscores
Consistent variable naming
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/environment/sinking_platform.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 37, 38, 42
- Functionality
Sink platform if collision with player detected
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
Could use more comments
- Changes from Increment 2
NO CHANGES

**/hades/boss_blocks.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 16-40, 45
- Functionality
Builds and destroys platforms used that boss will destroy in fight
- Naming
File named with underscores
Consistent variable naming
- Comments
Could use more comments
- Changes from Increment 2
NO CHANGES

**/hades/build_floor.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 16-40, 45
- Functionality
Builds ground used in boss fight
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/hades/camera_boss_hades.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 19, 22, 29, 33, 35
- Functionality
Centers camera on player during bossfight
The only different between this and the other camera cs files is that y_offset is 1f
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
Comments ok
- Changes from Increment 2
NO CHANGES

**/hades/warp.cs authored by Matthew Kaplan**
- Design
Empty if statements Lines 31-34 and 39-42
- Functionality
Warps position of player? Or hades? Unclear naming
- Naming
File named with underscores
Consistent variable naming
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/hades/warp_right.cs authored by Matthew Kaplan**
- Design
Empty if statements Lines 31-34 and 39-42
Identical to warp.cs
- Functionality
Warps position of player? Or hades? Unclear - Naming
Same as warp.cs except Vector3 value is different
- Naming
File named with underscores
Consistent variable naming
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/parallax background/parallax_back.cs authored by Matthew Kaplan**
- Design
Unused code comments in lines 21, 30, 33, 34
- Functionality
Move backmost layer of background at certain rate for illusion of depth
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
Could use more comments
- Changes from Increment 2
NO CHANGES

**/parallax background/parallax_fore.cs authored by Matthew Kaplan**
- Design
Unused code comments in lines 21, 30, 34, 35, 38
- Functionality
Move frontmost layer of background at certain rate for illusion of depth
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES except removing a line of whitespace

**/parallax background/parallax_mid.cs authored by Matthew Kaplan**
- Design
Unused code comments in lines 23, 33, 36, 37
Lots of empty space lines 24-26
- Functionality
Move middle layer of background at certain rate for illusion of depth
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/player/check_ground.cs authored by Matthew Kaplan**
- Design
No unused code comments
- Functionality
Identifies if the player is touching the ground or not
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/player/player_health.cs authored by Matthew Kaplan**
- Design
Delete unused code comments in lines 25, 40, 80
Timer wrong in line 38? Maybe remove
- Functionality
Sets player health, deducts health if collision with enemy detected, senses if player is dead, goes to game over screen if dead
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
Only one useful comment
- Changes from Increment 2
Added game over screen

**/player/player_movement.cs authored by Gavin Williams and Matthew Kaplan**
- Design
Delete unused code comments in lines 77, 96, 220, 228
Empty if statements for lines 220, 228
- Functionality
Activates specific player movements based on user input
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
Comments good
- Changes from Increment 2
Fixed knockback bugs

**/player/remove_heart.cs authored by Matthew Kaplan**
- Design
No unused code comments
- Functionality
Displays hearts representing player health
- Naming
File named with underscores
Inconsistent variable naming with underscores
- Comments
No comments, self explanatory
- Changes from Increment 2
NO CHANGES

**/player/slope_check.cs authored by Matthew Kaplan**
- Design
No unused code comments
- Functionality
Checks if player is on slope or not for movement, can this be combined with player_movement file?
- Naming
File named with underscores
Consistent variable naming with underscores
- Comments
Comments good
- Changes from Increment 2
NO CHANGES

**/player/sword.cs authored by Matthew Kaplan**
- Design
Delete or implement unused code comments in lines 35-43, 51, 65, 70, 80, 85, 96, 110
Functionality
Sword movement up and down
- Naming
File named with underscores
Consistent variable naming with underscore
- Comments
Comments good
- Changes from Increment 2
NO CHANGES

**/player/sword_check.cs authored by Matthew Kaplan
**
- Design
This file does nothing, delete or implement asap
- Functionality
Checks if sword hits enemy
- Naming
File named with underscores
Consistent variable naming with underscore
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

**/player/sword_collider.cs authored by Matthew Kaplan**
- Design
Looks like the replacement for sword_check, delete the other file
- Functionality
Checks if sword hits enemy
- Naming
File named with underscores
Consistent variable naming with underscore
- Comments
No useful comments
- Changes from Increment 2
NO CHANGES

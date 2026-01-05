# Technical Design Document



## Tools/Versions

* Unity Version 6000.0.62f1
* Visual studio 2022

## Programming techniques

##### Player:

* The player movement will by controlled by the new input system.
* The player can transform into different colors by adding a box collider under the player (where it will teleport) and checking if the player is grounded.

##### Progression:

* The levelunlocked (float) controlls the amount of levels that is unlocked and which levels are locked and which arent.
* The levelunlocked and the bonus stars are stored in a level manager which is a singleton.
* levelunlocked will be increased when player enters the finish portal.
* Bonus stars can be collected when the players collides with it.
* Bonusstars (float) controlls the amount of stars collected.

##### Mechanics:

* The moving platform will be controlled by a animator where i put in the start and end position.
* Button will be activated when the player collides with the button
* Button activation will be called through a event activation.
* Paint bucket using on rusty part can be done by clicking the paint bucket first then clicking the rusty part (onclick events)
* Button that toggles color to opposite can be done with a toggle function where true becomes false and false becomes true, the color will only change from black to white or white to black because the colors of the game is only black and white.

##### Obstacles:

* If player collides with spike, Run a respawn function which teleports the player to the start position of the level and adds 1 to the deaths increment.
* The rusty part will run a respawn function when standing on it only.



###### UI system:

* The hud will get the amount of items of a item from the inventory manager.
* The pauze button can be opened by activating the onclick() event.
* The amount of attempts will be get from the death manager.
* The game freezing when pauzing will be obtained by setting the timescale to 0.
* The buttons in the pauze menu will be activated by a onclick() event and will call a function from the pauze manager.
* The levels are locked if the previous level is not completed will be obtained by getting all the level numbers and check if level number -1 is not completed.
* The bonus stars of a level (float) can be checked from the levelmanager. from the levels.
* When loading in to the level selector screen. Count up all the bonus stars from all the levels and show the amount on the screen.
* If the bonus stars meets the amount requirement, unlock the bonus level.

# Challenge assignments from Microsoft Learn

## [Fibbonaci Series](/fibbonaciNumbers/Program.cs)
- A fundamental mathematical wonder to build using basic arithemetic and logical skills

### Task
- Series starts with 0 and 1
- Based on user input extend the series by adding succeeding number with the preceding number, i.e.,
<code>
    > Enter series length : 5
    
    > Output :
    0 1 1 2 3 5
</code>
- Output excludes '0' during building the series
- Limitiation :
    - `long` integer format does not support beyond the Fibbonaci series length of 92 or the 93<sup>nd</sup>number of the series - `7540113804746346429`

<hr>

## [Mini Game](/miniGame/)
- Mini game featuring a player's survival with limited resources, as mentioned in the [Challenge Project](https://learn.microsoft.com/en-gb/training/modules/challenge-project-create-mini-game/) for C# console applications

### Task
- Build the "[Missing Features](#missing-features)" and build the desired functionality of the game as mentioned below

### Game Function
- Variables
    - define size of game terminal
    - keep track locations of player and food
    - arrays for 'player-status' and 'food-items' to provide available player and food appearances
    - track current player and food appearance
- Methods
    - terminal window size function
    - Equate player status and appearance by food consumed
    - Temporarily and randomly place food
    - Temporarily and randomly freeze player movement
    - Move player by directional input
    - Setup initial game state

### Missing Features
- Code doesn't call Methods correctly and lacks expected functionality.
- The following features are to be coded to :
    - Determine if the player has consumed the food displayed.
    - Determine if the food consumed should freeze player movement.
    - Determine if the food consumed should increase player movement.
    - Increase movement speed.
    - Redisplay the food after it's consumed by the player.
    - Terminate execution if an unsupported key is entered.
    - Terminate execution if the terminal was resized.

### Learnings
- Reading through existing code and debugging
- Not stalling or getting 'lost in translation'
- Do as much as required, Not more.
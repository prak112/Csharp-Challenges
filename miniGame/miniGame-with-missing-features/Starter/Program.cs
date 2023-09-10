using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;

// Game termination deciders
bool terminalResize = false;
bool invalidInput = false;

// player state validation
bool playerEatsFood = false;
int movementSpeed = 0;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = {"('-')", "(^-^)", "(X_X)"};
string[] foods = {"@@@@@", "$$$$$", "#####"};

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;



// Initiate Gameplay
InitializeGame();
do
{
    // verify conditions
    terminalResize = TerminalResized();
    invalidInput = NonDirectionalInput();
    playerEatsFood = ConsumedFood();
    movementSpeed = AcceleratePlayer();

    // activate methods
    Move(terminalResize, invalidInput, movementSpeed);
    if(playerEatsFood == true)
    {
        ShowFood();
        ChangePlayer();
    }
}while (!terminalResize || !invalidInput);




#region Methods

// Clears the console, displays the food and player
void InitializeGame() 
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}

// Reads directional input from the Console and moves the player
void Move(bool terminalResize, bool invalidInput, int movementSpeed) 
{ 
    // close console if Terminal Resized
    if(terminalResize == true)
    {
        TerminateGame();        
    }

    // if user pressed non-directional keys, exit
    if(invalidInput == true)
    {
        TerminateGame();
    }
    
    // freeze player if player state is sick
    if(player == states[2])
    {
        FreezePlayer();
    }

    // Keep player position within the bounds of the Terminal window
    int lastX = playerX;
    int lastY = playerY;
    
    switch (Console.ReadKey(true).Key) 
    {
        case ConsoleKey.UpArrow:
            playerY--; 
            break;
		case ConsoleKey.DownArrow: 
            playerY++; 
            break;
		case ConsoleKey.LeftArrow:
            if (player == states[1])    // player is healthy, hence faster
            {   
                playerX -= movementSpeed;
            }
            else{
                playerX--;
            }
            break;
		case ConsoleKey.RightArrow:
            if (player == states[1])    // player is healthy, hence faster
            {   
                playerX += movementSpeed;
            } 
            else{
                playerX++;    
            }             
            break;
		case ConsoleKey.Escape:     
            terminalResize = true; 
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++) 
    {
        Console.Write(" ");
    }


    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}



// Displays random food at a random location
void ShowFood() 
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer() 
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer() 
{
    System.Threading.Thread.Sleep(4000);
    player = states[0];
}

#endregion



#region Helper Methods

// Accelerate the player
int AcceleratePlayer()
{
    if (player == states[1])
    {
        movementSpeed = 3;
    }
    else
    {
        movementSpeed = 0;
    }
    return movementSpeed;
}


// Returns true if the player location matches the food location
bool ConsumedFood() 
{
    // confirm player location overlaps food location, hence food consumed
    if (playerY == foodY && playerX == foodX)
    {
        return true;
    }
    return false;
}


// Returns true if the Terminal was resized 
bool TerminalResized() 
{
    // verify height and width
    if (height!= Console.WindowHeight - 1 || width!= Console.WindowWidth - 5)   // terminal resized
    {
        return true;
    }
    return false;
}

// Detects non-directional input, i.e., if user pressed other than arrow keys
bool NonDirectionalInput() 
{
    ConsoleKeyInfo keyInfo = Console.ReadKey();
        
    if (keyInfo.Key == ConsoleKey.UpArrow || 
        keyInfo.Key == ConsoleKey.DownArrow || 
        keyInfo.Key == ConsoleKey.LeftArrow || 
        keyInfo.Key == ConsoleKey.RightArrow) 
    {
        return false;
    }
    return true;
}

// Terminate game, if terminal resized or user pressed non-directional keys
void TerminateGame()
{
    Console.Clear();    // clear console
    Console.WriteLine("Console was resized OR non-directional keys were pressed.\nProgram exiting...");
    Thread.Sleep(2000);  // pause for 2 seconds
    Environment.Exit(0);    // close game
}

#endregion

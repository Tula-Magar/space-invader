# Our goal was to build a game in unity editor mode. If you want to make a application or launch the game then you can git clone our space invader projects and update the scoring codes.

# Environment setup 

Nicholas and I decided to build a 2D space invader game in unity. You must have Unity installed on your computer. 
Download the Unity from this link https://unity3d.com/get-unity/download?_ga=2.203091665.1743604503.1651158008-1988471870.1651158008. Unity provides free,
plus, and pro types of license users. You must register as a student and hobbyist to get a free Unity hub user license. 

Once you have done the above part, open the Unity. Unity might ask you to install the editor. If you want then you can 
install the unity editor. Once you open the Unity, you will get to see a "New Project" button on the top right. Click on "New Project"
and you will get to see a new screen. In the middle of the screen, you will see like the CSS border highlighted in blue. Make 
sure the border highlighted in the blue is in the 2D. On the right side of the screen, you will see the project name and 
location. You can name the project whatever you feel like the name but make sure you know the location. Location is a file
path and where it is storing the unity project. Now, click on the "Create project" button in the bottom right corner and go to the location in 
the file explorer. 

Now, you need to git clone our project.

	1: Open the terminal and type 
		    
      a) git clone https://github.com/TulaMagar/space-invader.git

Next, go inside the space-invader folder and copy everything. Now, go back to the unity project location that you created 
before. Open the Assets folder and delete everything. Now, paste the copied data from the space-invader folder into the Assets folder. 

Open or already opened Unity, you can click on the project name that you created. Once the project is done loading, you need to expand the Assets 
folder on the bottom left side. You need to go to the Scenes folder then on the right side, you will see the Menu scene. You must 
double-click on the Menu scene to load the menu scene. Click only one time on play on the top middle. Below image as a reference


<a href="https://ibb.co/M26dQW8"><img src="https://i.ibb.co/GxTmNBs/Capture.png" alt="reference image not found" border="0" width="100%" />

# Start menu

Now, you will see the menu list in the game mode. Hover on text changes denote as a button and they do something on click. There are 
two menu lists PLAY and GAME INFO as a button and Global High Score as text that won't change the text on hover. If you click on PLAY 
then it will load another scene called PlayGame. PlayGame will start the game of space invader. I will talk about PlayGame scene functionality 
later. If you click on GAME INFO then it will display basic space invader game information such as what keyboard needs to use to move the player 
left and right and shot toward the enemies. Global High Score will read the text called GlobalHighScore from the resource folder and display 
the data as a global high score. For example, if someone creates a new Global High Score then it's like someone broke the high score record 
of all users. All the players will get to see the global high score on the main menu of our space invader game. 


# PlayGame Scene

## Enemy 

0 to 45 enemies respawn at a time and start to shoot randomly toward the player. When the player completes the game and goes to the next 
level. The player will feel that enemies shoot randomly speed goes up. Enemies shoot randomly speed will go up as soon as the player 
levels up. The enemy doesn't have a life span like the player, the enemy can respawn as soon as the player kills all the enemies. 


## Enemy and ship movement 

Enemy and ship move automatically. When enemies move left and right and touch the border, enemies begin to a step toward the player. 
The player must destroy the enemies before enemies move toward and make it hard to win the game. 


## Player 

The player must use the space keyboard to shoot toward the enemies. Two arrows from the keyboard help to move the player left and right.
← this arrow will move the player to the left side. → this arrow will move the player to the right side. When the player projectile is
known as a bullet touch the enemy. The enemy will die and gets a 1-point score. If a player kills a ship then the player will get a 3-point score. 

In each game, the player gets three life spans. The player will respawn each time player dies up to three-time and after the third attempt, 
the game will be over. 

## High score vs score

I used Unity PlayerPrefs to store a high score on the player's personal computer. If the player moves to another personal computer then 
a high score won't display from one computer to another computer, unlike Global High Score from the main menu scene. A player's 
high score will only display on their personal computer. 

The point will keep adding to the score each time player kills the enemy or ship. If the score is higher than a High Score then 
that means the player broke their own score record and set their own new score record. 

## Quit

This quit button is very simple. If the player clicks on the QUIT button then the game application will close. 


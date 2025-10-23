# Boundary Test 1
For my first boundary test, I am testing my collision system. 
To test this, I am running two 'players' (just the circle hitboxes for now) into each other to see how they react and move. 
A pass: Both players bounce back from each other. 
Fail: the players do not collide. 

Result: Pass, however the knockback and movement needs to be tweaked. Someone must have changed the movement and knockback, and now I know I need to tweak it more as a result of this test. 

# Boundary Test 2
To test my logging class, I am testing to see if the class  continues logging even if the player is completely out of bounds, and out of the boundary of the game. 
To test this, I 'told' the players to move off of the screen, and logged their current position. 
Pass: The positionholder class continues to hold the position of a player and records it, even if they are off the screen. 
Fail: The class does not hold the position of the player. 

Result: Pass, I did not add a function to stop the class from recording if the players are off of the screen. So, the positions were still recorded. 


# Stress Test
For this stress test, I ran two players into each other again and again to see when they would no longer hit each other. Each time I increased the speed. 
Each time the players hit, their speed will be doubled. 
The goal is to see at what speed it takes for the players to no longer collide and faze through each other. 
Since I have acceleration based movement, the speed shows the current speed of the player. In the console, you can tell if there are collisions, even if they are off screen. 
When the collisions stop, then you know that the players have reached their top speed. 
A great part about this test is that the players will forever go back and hit each other. Therefore, once the console does not show a collision, this means that 
the players will not get any faster. The players only increase speed when they are hit. So after the last collision, the players should maintain a speed that is close to their top speed. 
The logging class also displays the speed at which they 'hit' each other in the console. 

Result: 
It seems that the players do not hit each other once they exeed a total speed of around 245. At the last hit before they stopped colliding, adding up the magnitude from both 
players (85+160) = 245. A single collision should not exceed this speed, since this is the last tested 'safe' speed. When developing puck shooting, we now know to ensure that no shot (or player) should ever exceed this speed. 

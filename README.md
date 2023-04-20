Turn-Based Console Battle
Implement a turn-based battle in which the player and the AI take turns attacking each other. The AI uses random actions and the player has to act accordingly.
1) Battle System
   Player and AI each start with 10 hit points (HP).
   The player can choose between three different actions using the number keys:
   Attack: Deal 1-2 damage to the enemy.
   Heal: Increase your HP by 2 (max. 10 HP).
   Defend: Negate all incoming damage until the next turn.
   After the player has taken their turn, the AI chooses one of two actions:
   Attack (65% chance): Deal 2-4 damage to the player.
   Charge (35% chance): Print a message that the enemy is charging energy. In the following turn a deadly attack is unleashed that instantly kills the player if they don't defend.
   The battle continues until either the player's or the enemy's HP reach zero.
2) Game Design
   You might have noticed that the game has a few glaring issues that make it feel unfair and not very fun to play. Take a step back from the code and think about the problems the system has in its current state. Is the game too simple? Is it too repetitive? Is it unbalanced? Make a few notes about fundamental issues you identified with the core game loop. How would you improve the game to make it more fun to play?
   Implement your ideas by creating a new and challenging enemy. You're free to change anything you want - player actions, enemy attacks and even the game mechanics can be completely different. Be creative!
   Create a new thread in the corresponding Moodle forum. Post your notes and a short summary of your new version, as well as a link to your code, so that other students can play your game (e.g. with https://pastebin.com/).
   Choose at least one other thread that has the least amount of replies (sort the threads by replies first). Copy their code into a new script, try out their game and post some feedback on their ideas.
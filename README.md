# Card Game Builder

The idea of this project came about when I had to develop a card game using Unity. After a brief research, I realized that there are no card game plugins in the Unity Assets store, at least not for free. So I decided to make a generic plugin that could help some developers make their own card games. You are free to make all the changes you need to design your game.

## Features

### - Strong use of Scriptable Objects (Create classes instances using the Editor)
### - Pack of prefabs 
### - Example Scene
### - Create Cards easily by name
### - Create Players easily
### - Deck, Hand, Field and 
### - Attack
### - Drop Card
### - Draw Card
### - Kill Card
### - Player State
### - Diferent logics to cards according to their positions in game

## How to use
You can see the Example Scene to have an idea of how the plugin works. I advise to you to use the Data folder because this folder has a lot of usable objects.

If you don't want to start from zero, follow this steps:

To create instances on Editor: Right click on Project Tab/Create/Card Assets/...

1. Create a ResourcesManager in a folder called "Resources" (it must have this name);
2. Create many cards as you like using the editor;
3. Add the cards to the list in you ResourcesManager
4. Create a Canvas and put it on your scene
5. Put the Main prefab inside the canvas
6. Put 2 players prefabs inside the canvas
7. Create 2 diferent players using the editor
8. Create you deck passing the name of the card you have created to the deck list
9. Crete all the logics neededs (Deck, Hand, Field, Cemitery)
10. Create the States normal and attacking
11. Finish you player
12. Go to your 2 players and set their stats
13. Go to Main and set the 2 players and the current player
14. Run

## Using the actual content

If you plan to use the scripts and objects I made, you just need to:
1. Create a Canvas to your scene
2. Add Main prefab
3. Add 2 players using the prefab
4. Add the players stats to the 2 players
5. Set the players reference into the Main script
6. Run 

## Diferent Logics
Choose how your card is going to behave according to its logic. The logics are diferent if the card is in a diferent position. Ex: field, deck, hand...

## Attack, Drop, Draw and Kill

Inside the Player script, you'll find those functions. You may change then as you wish to fit into your game logic. If you need more interactions events  to your card, just add then at the event trigger component attatched in the card prefab.

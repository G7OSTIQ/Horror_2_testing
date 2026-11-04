# Abandoned Building: one fixed maze (no random generation)

The map is ONE floor plan, written once in `FixedMazeLayout.cs`. It is identical every time you press Play.
Ground floor only, 88 m x 64 m (22 x 16 cells of 4 m), olive-yellow blurry low-poly textures.

What is in it
- Start: front door in the Foyer (south). Exit: the red-marked door in the Boiler room (north). Opening it ends the game ("YOU ESCAPED").
- 12 furnished rooms: Foyer, Living, Kitchen, 3 Bedrooms, Bathroom, Study, Library, Nursery, Storage, Boiler.
- Every door, wardrobe, closet, cupboard, fridge and drawer is its own openable part (press E / your interact button).
- Wardrobes and closets are hiding spots. Small props (cups, books, bear...) can be picked up.
- 7 boarded-up passages (go round), 3 smashed walls (shortcuts), 14 boarded windows, empty doorways, dead ends with closets.

## Setup (5 minutes)
1. Delete the OLD maze scripts if you imported them: MazeGenerator.cs, MazeManager.cs, PortalDoor.cs (they clash with the new files).
2. Copy `Resources/` into `Assets/` (so you have Assets/Resources/MazeKit/Models and /Textures).
3. Copy the `Scripts/` folder into `Assets/`. It REPLACES the maze versions of: CreepEnemy, EnemyDoorOpener, FurnitureSetup, HingedDoor, Openable, SaveData, SlidingDrawer, Wardrobe. Your core scripts (GameManager, FirstPersonController, PlayerInteractor, etc.) stay as they are.
4. New empty scene. Create an empty GameObject named `Maze`: Add Component > Nav Mesh Surface, then > Fixed Maze Builder.
   Also add `HorrorScreenEffects` to it (the fade + scanlines).
5. Put your Player (Capsule with FirstPersonController, etc.) and the Creep in the scene anywhere. The builder moves them to the start / Creep spot when you press Play.
6. Delete any old save (GameManager > Delete Save) and press Play.

Tip: if the Console shows "Can't find ... MazeKit/Models/...", the Resources folder is in the wrong place.
In the Fixed Maze Builder you can turn off `Spawn Creep` while you explore, or tick `Crisp Pixels` for sharper textures.

Honest note: this was written and checked outside Unity (the floor plan was verified by code: every room reachable, every room has a door, the exit is 57 steps from the start). I could not press Play in Unity, so if the Console shows a red error, send me the first line and I will fix it.

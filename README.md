# Week-6-University-Game-A-Week-Game-Continued

I made this game for the game a week I did for University and wanted to continue this one and see where it takes me, I focused on the making the general appearance and utility of the game look like an actual game instead of a game jam game, that includes remaking the main screen, adding in controls screens and credits screen, retry button, pause screen, cutscenes (the cutscene in the game is a placeholder), making the player controller less floaty, remaking the UI in game and a jump cooldown bar.

On the more technical side, i explored dontdestroyonload (retry.cs) to carry over variables, an example of this is the retry button which works by taking the scene name when the player dies and transferring that into the retry scriptso when the player clicks retry it takes them back to whatever scene they were just previously in. I did run into an issue with dontdestroyonload where the loadvalue would keep on duplicating every time the player would load into the launcher so i did have to write another script called StopDuplicate.cs to avoid the gameobject being duplicated which would eventually lead to the performance decreasing.

I may work on this more if i find the time to do so.

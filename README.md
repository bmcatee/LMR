# LMR
"lil mini rpg" is an idle game with RPG elements. Players may create a character, choosing their class, a weapon, and an accessory, before setting out into combat. Fighting, movement, and progression all happen automatically; when the character (inevitably) dies, they are sent back to the first gameplay screen but keep their accumulated XP and Gold.

An in-game menu gives more details on the mechanics of the game and how it is played. You must create a character before you are allowed to play the game; attempting to select "Play Game" (and many other menu functions) without creating a character first will take you to character creation.

Player data is saved to a local database; currently there is only one save slot, by design.

Feature requirements:
* Dictionary/list usage
* Async implementation for save/load
* Error logging, saved to a .log file ("lmr_error_log.log")

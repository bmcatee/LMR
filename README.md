# LMR
"lil mini rpg" is an idle game with RPG elements. Players may create a character, choosing their class, a weapon, and an accessory, before setting out into combat. Fighting, movement, and progression all happen automatically; when the character (inevitably) dies, they are sent back to the first gameplay screen but keep their accumulated XP and Gold.

Each Job has its own "Growth Values"; each time the player levels up, they will gain those values. IE: A player at level 1 has a starting Luck stat of 5 and a Luck Growth of 5 -  at level 2, that player will now have 10 Luck.

At any time the player may change their Job via the main menu; doing so resets the player's XP to zero but converts a portion of the XP lost into Gold. Gold is (or at least will be) used to purchase new weapons & accessories, and upgrade the items the player already has.

A player moves and attacks based on their MOV and ATK SPD stats (lower numbers are better [for now]!). Likewise, enemies automatically attack based on their own ATK SPD values (note: if you are hit by an enemy, you will be knocked back by one tile!)

Weapons and Accessories provide static bonuses to stats, as well as (in the future) offering unique perks that alter aspects of gameplay, such as increasing dodge chances, altering elemental damage type, and more. Weapons & Accessories will be able to be leveled up, increasing the static stat bonuses they provide.

An attack is based off a player's total combined stats (Job, Weapon, and Accessory) and weapon choice. A weapon has two "attack stats", each with their own percentage; the damage done to the enemy is then a calculation of these stats. As an example:

Bob the Knight has 25 Strength and 10 Dexterity. The Sword's attack stats are: "Strength (70%) and Dexterity (30%)" - when Bob attacks something, their base attack value is then 21 (or 17.5 from STR plus 3 from DEX, rounded up). This base value is then modified by a further random roll, and may critically succeed or fail.

Each stage consists of 16 'tiles' the player must traverse before reaching the next stage; the enemies on each stage are set to the equivalent level, so an enemy on Stage 2 will also be Level 2 (with an appropriate increase to stats).

Player data is saved to a local database; currently there is only one save slot, by design.

Feature requirements:
* Dictionary/list usage
* Async implementation for save/load
* lol idk i'll figure smth out in the next 36h

namespace lilminirpg
{
    internal class Movement
    {
        // _gameDelay variable allows control of game speed; currently set to 30fps
        private static int _gameDelay = 30;
        private static bool _wasAttacked = false;
        private static bool _didWin = false;

        // This is where the player moves through the stage tiles; if the player encounters an enemy, the attack methods are called
        public async static void MoveThroughScreen(Player currentPlayer, Enemy[] currentStageArray)
        {
            int frame = 0;
            bool fightIntroText = true;
            bool stageIntroText = true;
            ResetPlayerFrames(currentPlayer);
            Enemy currentEnemy = new Enemy();
            currentPlayer.StageTile = 0;
            if (currentPlayer.MaximumStage < currentPlayer.CurrentStage)
            {
                currentPlayer.MaximumStage = currentPlayer.CurrentStage;
            }
            await SaveLoad.SaveGame(currentPlayer);

            // Will exit to a Game Over if the player has 0 HP
            while (currentPlayer.HealthPointsCurrent > 0)
            {
                while (currentPlayer.StageTile < currentStageArray.Length - 1)
                {
                    if (currentPlayer.HealthPointsCurrent > 0)
                    {
                        ++frame;
                        Enemy nextEnemy = UpcomingEnemy(currentStageArray, currentPlayer.StageTile + 1);
                        currentEnemy = currentStageArray[currentPlayer.StageTile + 1];
                        currentEnemy = ResetEnemyFrames(currentEnemy);

                        if (stageIntroText)
                        {
                            Console.WriteLine($"You begin your quest!");
                            stageIntroText = false;
                        }

                        while (_wasAttacked || _didWin)
                        {
                            if (frame % currentPlayer.FrameMove == 0)
                            {
                                _wasAttacked = false;
                                _didWin = false;
                                Console.WriteLine($"{currentPlayer.Name} the {currentPlayer.PlayerJob.Name} at tile {currentPlayer.StageTile}, moving to {currentPlayer.StageTile + 1} || Next tile contains: {currentEnemy.Name}, next enemy is {nextEnemy.Name} at tile {nextEnemy.StageTile}.");
                            }
                            ++frame;
                            Thread.Sleep(TimeSpan.FromMilliseconds(_gameDelay));
                        }
                        // If upcoming tile contains "Empty Ground" then move
                        if (currentEnemy.Name == "Empty Ground")
                        {
                            if (frame % currentPlayer.FrameMove == 0 || frame == 2)
                            {
                                fightIntroText = true;
                                ++currentPlayer.StageTile;

                                if (currentPlayer.StageTile < currentStageArray.Length - 1)
                                {
                                    currentEnemy = currentStageArray[currentPlayer.StageTile + 1];
                                    currentEnemy = ResetEnemyFrames(currentEnemy);
                                    Console.WriteLine($"{currentPlayer.Name} the {currentPlayer.PlayerJob.Name} at tile {currentPlayer.StageTile}, moving to {currentPlayer.StageTile + 1} || Next tile contains: {currentEnemy.Name}, next enemy is {nextEnemy.Name} at tile {nextEnemy.StageTile}.");
                                }

                                await SaveLoad.SaveGame(currentPlayer);
                            }
                        }
                        // If upcoming tile contains anything else, then fight
                        else
                        {
                            if (frame % currentPlayer.FrameAttack == 0)
                            {
                                if (fightIntroText)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"Fight!!!");
                                }
                                fightIntroText = false;
                                (currentPlayer, currentEnemy, currentStageArray) = await PlayerAttack(currentPlayer, currentEnemy, currentStageArray);
                            }

                        }
                        // If the enemy's attack frame lands before the player's, it's an ambush attack; these may do more damage or something in the future
                        if (currentEnemy.Name != "Empty Ground" && frame % currentEnemy.FrameAttack == 0 && currentEnemy.HealthPointsCurrent > 0 && currentPlayer.StageTile == currentEnemy.StageTile - 1)
                        {
                            if (fightIntroText)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Ambush attack!!!");
                            }
                            fightIntroText = false;
                            (currentPlayer, currentEnemy) = EnemyAttack(currentPlayer, currentEnemy, currentStageArray);
                        }
                        Thread.Sleep(TimeSpan.FromMilliseconds(_gameDelay));
                    }
                    else
                    {
                        break;
                    }
                }
                // If the player survived, it's on to the next stage
                if (currentPlayer.HealthPointsCurrent > 0)
                {
                    ResetPlayerFrames(currentPlayer);
                    ResetEnemyFrames(currentEnemy);
                    ++currentPlayer.CurrentStage;
                    await SaveLoad.SaveGame(currentPlayer);
                    QuestEngine.InitStageArray(currentPlayer);
                }
                // Or if they died, it's game over
                else
                {
                    ResetPlayerFrames(currentPlayer);
                    ResetEnemyFrames(currentEnemy);
                    Console.WriteLine();
                    Console.WriteLine("You lose! Game over!! Press Enter to continue");
                    currentPlayer.CurrentStage = 1;
                    currentPlayer.HealthPointsCurrent = currentPlayer.HealthPointsMax;
                    await SaveLoad.SaveGame(currentPlayer);
                    Console.ReadKey();
                    await Menus.MenuGeneric("MenuMain");
                }
            }
        }
        // Here the player attacks; if the enemy's HP reaches 0 the player "wins" and gains XP/GP
        public async static Task<(Player Player, Enemy Enemy, Enemy[] StageArray)> PlayerAttack(Player currentPlayer, Enemy currentEnemy, Enemy[] currentStageArray)
        {
            Console.WriteLine($"Players HP: {currentPlayer.HealthPointsCurrent} - Enemy HP: {currentEnemy.HealthPointsCurrent} - PlayerPos: {currentPlayer.StageTile}");
            Enemy nextEnemy = UpcomingEnemy(currentStageArray, currentPlayer.StageTile + 1);
            int RollResults = DiceRoller.DamageRoller(currentPlayer);
            currentEnemy.HealthPointsCurrent = currentEnemy.HealthPointsCurrent - RollResults;
            Console.WriteLine($"You attack with your {currentPlayer.WornWeapon.Name} for {RollResults} dmg! The {currentEnemy.Name} now has {currentEnemy.HealthPointsCurrent} HP.");
            if (currentEnemy.HealthPointsCurrent < 1)
            {
                Console.WriteLine();
                Console.WriteLine($"You win! You gain {currentEnemy.XPDropped} XP and {currentEnemy.GoldDropped} GP!");
                currentPlayer.XPCurrent += currentEnemy.XPDropped;
                currentPlayer.GoldCurrent += currentEnemy.GoldDropped;
                if (currentPlayer.XPCurrent >= currentPlayer.XPToLevel)
                {
                    ++currentPlayer.CurrentLevel;
                    currentPlayer = PlayerMethods.PlayerLevelUp(currentPlayer);
                    Console.WriteLine();
                    Console.WriteLine($"DING! YOU ARE NOW LEVEL {currentPlayer.CurrentLevel}");
                }
                currentStageArray[currentEnemy.StageTile] = EnemyMethods.CreateDummy();
                currentEnemy = EnemyMethods.CreateDummy();
                nextEnemy = UpcomingEnemy(currentStageArray, currentPlayer.StageTile + 1);
                await SaveLoad.SaveGame(currentPlayer);
                _didWin = true;
                return (currentPlayer, currentEnemy, currentStageArray);
            }
            return (currentPlayer, currentEnemy, currentStageArray);
        }

        // Enemy attacks are on an independent timer from the player, and may happen at any moment, but may only hit a player if they are in the tile adjecent to the enemy
        // If the enemy lands a hit, the player is knocked back by one tile and must move forward again
        public static (Player Player, Enemy Enemy) EnemyAttack(Player currentPlayer, Enemy currentEnemy, Enemy[] currentStageArray)
        {
            int RollResults = DiceRoller.DamageRoller(currentEnemy);
            currentPlayer.HealthPointsCurrent = currentPlayer.HealthPointsCurrent - RollResults;
            --currentPlayer.StageTile;
            _wasAttacked = true;
            Console.WriteLine($"The {currentEnemy.Name} {currentEnemy.AttackWord} you for {RollResults} dmg!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"KNOCKBACK!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"The {currentEnemy.Name} successfully knocks you back to position {currentPlayer.StageTile}!");
            Console.WriteLine($"Your HP is {currentPlayer.HealthPointsCurrent}/{currentPlayer.HealthPointsMax} and the {currentEnemy.Name} has {currentEnemy.HealthPointsCurrent}/{currentEnemy.HealthPointsMax} HP.");
            return (currentPlayer, currentEnemy);
        }

        // These keep the move & attack frames updated and in line with the timer
        public static Player ResetPlayerFrames(Player currentplayer)
        {
            currentplayer.FrameMove = currentplayer.StatMoveSpeed;
            currentplayer.FrameAttack = currentplayer.StatAttackSpeed;
            return currentplayer;
        }
        public static Enemy ResetEnemyFrames(Enemy currentenemy)
        {
            currentenemy.FrameMove = currentenemy.StatMoveSpeed;
            currentenemy.FrameAttack = currentenemy.StatAttackSpeed;
            return currentenemy;
        }
        
        // This lets us know what the next available enemy in the stage will be
        public static Enemy UpcomingEnemy(Enemy[] currentStageArray, int tilePosition)
        {
            Enemy nextEnemy = new Enemy();
            bool w = false;
            while (w == false)
            {
                for (int i = 0; i < currentStageArray.Length - 1; ++i)
                {
                    if ((currentStageArray[i].Name != "Empty Ground"))
                    {
                        nextEnemy = currentStageArray[i];
                        w = true;
                        break;
                    }
                }
                if (w == false)
                {
                    nextEnemy = EnemyMethods.CreateDummy();
                    nextEnemy.StageTile = tilePosition;
                    w = true;
                }
            }
            return nextEnemy;
        }
    }
}

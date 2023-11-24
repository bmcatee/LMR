namespace lilminirpg
{
    internal class Movement
    {
        private static int _frame = 0;
        private static int _gameDelay = 30;
        private static int _playerPos = 0;
        private static int _length = 0;
        private static int _playerAttackTimeOriginal = 20;
        private static int _playerAttackTimeCurrent = 0;
        private static int _playerMoveTimeOriginal = 20;
        private static int _playerMoveTimeCurrent = 0;
        private static int _enemyAttackTimeOriginal = 40;
        private static int _enemyAttackTimeCurrent = 0;
        private static bool _fightIntroText = false;
        private static Player _currentPlayer = new Player();
        // BAD HARDCODE ARRAY INIT, FIX
        // private static Enemy[] _stageEnemies = new Enemy[16];
        private static Enemy _currentEnemy = new Enemy();
        private static Enemy _nextEnemy = new Enemy();

        public static void MoveThroughScreen(Player currentplayer, Enemy[] enemiesonscreen)
        {

            _playerMoveTimeCurrent = currentplayer.StatMoveSpeed;
            _playerAttackTimeCurrent = currentplayer.StatAttackSpeed;
            _enemyAttackTimeCurrent = _enemyAttackTimeOriginal;
            _currentPlayer = currentplayer;
            _length = enemiesonscreen.Length - 1;

            if (_currentPlayer.MaximumStage < _currentPlayer.CurrentStage)
            {
                _currentPlayer.MaximumStage = _currentPlayer.CurrentStage;
            }
            SaveLoad.SaveGame(_currentPlayer);

            while (_currentPlayer.HealthPointsCurrent > 0)
            {
                while (_playerPos < _length)
                {
                    if (_currentPlayer.HealthPointsCurrent > 0)
                    {
                        _currentEnemy = enemiesonscreen[_playerPos + 1];
                        if (_playerPos < _length -1)
                        {
                            _nextEnemy = enemiesonscreen[_playerPos + 2];
                        }
                        else
                        {
                            _nextEnemy.Name = "New stage!";
                        }

                        if (_currentEnemy.Name == "Empty Ground")
                        {
                            if (_playerMoveTimeCurrent == _frame)
                            {
                                Console.WriteLine($"{_currentPlayer.Name} the {_currentPlayer.PlayerJob.Name} at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {enemiesonscreen[_playerPos + 1].Name}");

                                _playerMoveTimeCurrent += _playerMoveTimeOriginal;
                                _playerAttackTimeCurrent += _playerAttackTimeOriginal;
                                ++_playerPos;
                                SaveLoad.SaveGame(_currentPlayer);
                            }
                        }
                        else
                        {
                            if (_playerAttackTimeCurrent == _frame)
                            {
                                Console.WriteLine($"{_currentPlayer.Name} the {_currentPlayer.PlayerJob.Name} at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {enemiesonscreen[_playerPos + 1].Name}");
                                if (!_fightIntroText)
                                {
                                    Console.WriteLine($"Fight!!!");
                                }
                                _fightIntroText = true;
                                _playerMoveTimeCurrent += _playerMoveTimeOriginal;
                                _playerAttackTimeCurrent += _playerAttackTimeOriginal;
                                PlayerAttack();
                            }
                        }
                        // CHECK TO SEE IF PLAYER IS IN TILE NEXT TO MOB
                        if (_enemyAttackTimeCurrent == _frame)
                        {
                            _enemyAttackTimeCurrent += _enemyAttackTimeOriginal;
                            if (_currentEnemy.Name != "Empty Ground" && _currentEnemy.HealthPointsCurrent > 0)
                            {
                                if (!_fightIntroText)
                                {
                                    Console.WriteLine($"Ambush attack!!!");
                                }
                                _fightIntroText = true;
                                EnemyAttack();
                            }
                        }
                        Thread.Sleep(TimeSpan.FromMilliseconds(_gameDelay));
                        _frame++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (_currentPlayer.HealthPointsCurrent > 0)
                {
                    _playerPos = 0;
                    _frame = 0;
                    _currentPlayer.CurrentStage = _currentPlayer.CurrentStage + 1;
                    _length = 0;
                    _playerAttackTimeOriginal = 20;
                    _playerAttackTimeCurrent = 0;
                    _playerMoveTimeOriginal = 20;
                    _playerMoveTimeCurrent = 0;
                    _enemyAttackTimeOriginal = 40;
                    _enemyAttackTimeCurrent = 0;
                    _fightIntroText = false;
                    SaveLoad.SaveGame(_currentPlayer);
                    QuestEngine.InitStageArray(_currentPlayer);
                }
                else
                {
                    _playerPos = 0;
                    _frame = 0;
                    _length = 0;
                    _playerAttackTimeOriginal = 20;
                    _playerAttackTimeCurrent = 0;
                    _playerMoveTimeOriginal = 20;
                    _playerMoveTimeCurrent = 0;
                    _enemyAttackTimeOriginal = 40;
                    _enemyAttackTimeCurrent = 0;
                    _fightIntroText = false;
                    Console.WriteLine("You lose! Game over!! Press Enter to continue");
                    _currentPlayer.CurrentStage = 1;
                    _currentPlayer.HealthPointsCurrent = _currentPlayer.HealthPointsMax;
                    SaveLoad.SaveGame(_currentPlayer);
                    Console.ReadKey();
                    Menus.MenuGeneric("MenuMain");
                }
            }
        }

        public static void PlayerAttack()
        {
            Console.WriteLine($"Player HP: {_currentPlayer.HealthPointsCurrent} - Enemy HP: {_currentEnemy.HealthPointsCurrent} - PlayerPos: {_playerPos}");

            int RollResults = DiceRoller.DamageRoller(_currentPlayer);
            _currentEnemy.HealthPointsCurrent = _currentEnemy.HealthPointsCurrent - RollResults;
            Console.WriteLine($"You attack with your {_currentPlayer.WornWeapon.Name} for {RollResults} dmg! The {_currentEnemy.Name} now has {_currentEnemy.HealthPointsCurrent} HP.");
            if (_currentEnemy.HealthPointsCurrent < 1)
            {
                Console.WriteLine($"You win! You gain {_currentEnemy.XPDropped} XP and {_currentEnemy.GoldDropped} GP!");
                _currentPlayer.XPCurrent += _currentEnemy.XPDropped;
                _currentPlayer.GoldCurrent += _currentEnemy.GoldDropped;
                if (_currentPlayer.XPCurrent >= _currentPlayer.XPToLevel)
                {
                    ++_currentPlayer.CurrentLevel;
                    _currentPlayer = PlayerMethods.PlayerLevelUp( _currentPlayer );
                    Console.WriteLine($"DING! YOU ARE NOW LEVEL {_currentPlayer.CurrentLevel}");
                }
                SaveLoad.SaveGame(_currentPlayer);
                Console.WriteLine($"{_currentPlayer.Name} the {_currentPlayer.PlayerJob.Name} at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {_nextEnemy.Name}");
                _fightIntroText = false;
                ++_playerPos;
            }
        }
        public static void EnemyAttack()
        {
            int RollResults = DiceRoller.DamageRoller(_currentEnemy);
            _currentPlayer.HealthPointsCurrent = _currentPlayer.HealthPointsCurrent - RollResults;
            Console.WriteLine($"The {_currentEnemy.Name} attacks you for {RollResults} dmg! " +
            $"Your HP is {_currentPlayer.HealthPointsCurrent}/{_currentPlayer.HealthPointsMax} and the {_currentEnemy.Name} has {_currentEnemy.HealthPointsCurrent}/{_currentEnemy.HealthPointsMax} HP.");
        }
    }
}

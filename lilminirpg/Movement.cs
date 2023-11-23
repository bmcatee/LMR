using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lilminirpg
{
    internal class Movement
    {
        private static int _frame = 0;
        private static int _gameDelay = 30;
        private static int _playerPos = 0;
        private static int _length = 0;
        private static int _playerAttackOriginal = 20;
        private static int _playerAttackCurrent = 0;
        private static int _playerMoveOriginal = 20;
        private static int _playerMoveCurrent = 0;
        private static int _enemyAttackOriginal = 40;
        private static int _enemyAttackCurrent = 0;
        private static bool _fightIntroText = false;
        private static Player _currentPlayer = new Player();
        // BAD HARDCODE ARRAY INIT, FIX
        // private static Enemy[] _stageEnemies = new Enemy[16];
        private static Enemy _currentEnemy = new Enemy();

        public static void MoveThroughScreen(Player currentplayer, Enemy[] enemiesonscreen)
        {

            _playerMoveCurrent = _playerMoveOriginal;
            _playerAttackCurrent = _playerAttackOriginal;
            _enemyAttackCurrent = _enemyAttackOriginal;
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
                        _currentEnemy = enemiesonscreen[_playerPos+1];
                        if (_currentEnemy.Name == "Empty Ground")
                        {
                            if (_playerMoveCurrent == _frame)
                            {
                                Console.WriteLine($"{_currentPlayer.Name} the {_currentPlayer.PlayerJob.Name} at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {enemiesonscreen[_playerPos + 1].Name}");

                                _playerMoveCurrent += _playerMoveOriginal;
                                _playerAttackCurrent += _playerAttackOriginal;
                                ++_playerPos;
                                SaveLoad.SaveGame(_currentPlayer);
                            }
                        }
                        else
                        {
                            if (_playerAttackCurrent == _frame)
                            {
                                Console.WriteLine($"{_currentPlayer.Name} the {_currentPlayer.PlayerJob.Name} at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {enemiesonscreen[_playerPos + 1].Name}");
                                if (!_fightIntroText)
                                {
                                    Console.WriteLine($"Fight!!!");
                                }
                                _fightIntroText = true;
                                _playerMoveCurrent += _playerMoveOriginal;
                                _playerAttackCurrent += _playerAttackOriginal;
                                PlayerAttack();
                            }
                        }
                        // CHECK TO SEE IF PLAYER IS IN TILE NEXT TO MOB
                        if (_enemyAttackCurrent == _frame)
                        {
                            _enemyAttackCurrent += _enemyAttackOriginal;
                            if (_currentEnemy.Name != "Empty Ground" && _currentEnemy.HealthPointsCurrent > 0)
                            {
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
                    _currentPlayer.CurrentStage = _currentPlayer.CurrentStage + 1;
                    SaveLoad.SaveGame(_currentPlayer);
                    QuestEngine.InitStageArray(_currentPlayer);
                }
                else
                {
                    _playerPos = 0;
                    _frame = 0;
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

            DiceRoller _diceRoller = new DiceRoller();
            int RollResults = (_diceRoller.RollDice(1, 5));
            _currentEnemy.HealthPointsCurrent = _currentEnemy.HealthPointsCurrent - RollResults;
            Console.WriteLine($"You attack with your {_currentPlayer.WornWeapon.Name} for {RollResults} dmg! The {_currentEnemy.Name} now has {_currentEnemy.HealthPointsCurrent} HP.");
            if (_currentEnemy.HealthPointsCurrent < 1)
            {
                Console.WriteLine($"You win! You gain {_currentEnemy.XPDropped} XP and {_currentEnemy.GoldDropped} GP!");
                _currentPlayer.XPCurrent += _currentEnemy.XPDropped;
                _currentPlayer.GoldCurrent += _currentEnemy.GoldDropped;
                SaveLoad.SaveGame(_currentPlayer);
                Console.WriteLine($"{_currentPlayer.Name} the {_currentPlayer.PlayerJob.Name} at position {_playerPos}, moving to {_playerPos + 1}");
                _fightIntroText = false;
                ++_playerPos;
            }
        }
        public static void EnemyAttack()
        {
            DiceRoller _diceRoller = new DiceRoller();
            int RollResults = (_diceRoller.RollDice(1, 5));
            _currentPlayer.HealthPointsCurrent = _currentPlayer.HealthPointsCurrent - RollResults;
            Console.WriteLine($"The {_currentEnemy.Name} attacks you for {RollResults} dmg! " +
            $"Your HP is {_currentPlayer.HealthPointsCurrent}/{_currentPlayer.HealthPointsMax} and the {_currentEnemy.Name} has {_currentEnemy.HealthPointsCurrent}/{_currentEnemy.HealthPointsMax} HP.");
        }
    }
}

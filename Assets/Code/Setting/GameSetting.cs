using System;
using UnityEngine;

namespace Code.Setting
{
    [CreateAssetMenu(fileName = nameof(GameSetting), menuName = "Setting/GameSetting")]
    public sealed class GameSetting : ScriptableObject
    {
        [SerializeField] private GameFeildSetting _gameFieldSetting;

        public int GameFieldSizeX => _gameFieldSetting.gameFieldSizeX;
        public int GameFieldSizeY => _gameFieldSetting.gameFieldSizeY;
        public int SmallPocketCount => _gameFieldSetting.smallPocketCount;
        public int BigPocketCount => _gameFieldSetting.bigPocketCount;

        [Serializable]
        private struct GameFeildSetting
        {
            public int gameFieldSizeX;
            public int gameFieldSizeY;
            public int smallPocketCount;
            public int bigPocketCount;
        }
    }
}

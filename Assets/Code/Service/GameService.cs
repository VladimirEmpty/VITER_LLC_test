using System.Collections.Generic;
using UnityEngine;

using Code.GUI.MVC;
using Code.GUI.Screens.StartGame;
using Code.GUI.Screens.GameResult;
using Code.GUI.Screens.Game;
using Code.Setting;
using Code.Data;

namespace Code.Service
{
    public sealed class GameService : IService
    {
        private IDictionary<int, bool> _gameFieldStateTable;
        private LinkedList<int> _gameUpdateCellIndexList;

        public GameService(GameSetting gameSetting)
        {
            _gameUpdateCellIndexList = new LinkedList<int>();
            _gameFieldStateTable = new Dictionary<int, bool>();

            GameSetting = gameSetting;            
        }

        public GameSetting GameSetting { get; }
        public bool IsWin { get; private set; }
        public bool IsPlay { get; private set; }

        public GameFieldUpdateViewItemData GetUpdateViewItemData()
        {
            //ADD type win or redraw
            var data = new GameFieldUpdateViewItemData(IsWin ? UpdateStateType.Win : UpdateStateType.Redraw);
            var node = _gameUpdateCellIndexList.First;

            while (node != null)
            {
                data.updateCellTable[node.Value] = _gameFieldStateTable.ContainsKey(node.Value);
                node = node.Next;
            }

            _gameUpdateCellIndexList.Clear();

            return data;
        }

        public void AddItem(int cellIndex, bool isCheckWin = true)
        {
            _gameFieldStateTable.Add(cellIndex, true);
            _gameUpdateCellIndexList.AddFirst(cellIndex);

            if(isCheckWin & cellIndex < 100)
                CheckGameWin();

            Save();
        }

        public bool IsContainItem(int cellIndex) => _gameFieldStateTable.ContainsKey(cellIndex);

        public void RemoveItem(int cellIndex)
        {
            _gameFieldStateTable.Remove(cellIndex);
            _gameUpdateCellIndexList.AddFirst(cellIndex);
        }

        public void StatGame()
        {
            IsPlay = true;
            IsWin = false;

            Load();

            ConectorMVC.UpdateController<GameScreenController>();
        }

        public void EndGame()
        {
            PlayerPrefs.DeleteKey(nameof(GameService));

            foreach(var el in _gameFieldStateTable)
            {
                _gameUpdateCellIndexList.AddLast(el.Key);
            }

            _gameFieldStateTable.Clear();
            IsPlay = false;
            IsWin = false;

            ConectorMVC.UpdateController<GameScreenController>();
            ConectorMVC.UpdateController<StartGameScreenController>();
        }

        private void CheckGameWin()
        {
            var cellIndexList = new LinkedList<int>();
            var cellHash = 0;

            //ONLY Horizontal Line
            for(var y = 0; y < GameSetting.GameFieldSizeY; ++y)
            {
                for(var x = 0; x < GameSetting.GameFieldSizeX; ++x)
                {
                    cellHash = GameCommon.ConvertToHash(x, y);

                    if (!_gameFieldStateTable.ContainsKey(cellHash))
                    {
                        cellIndexList.Clear();
                        break;
                    }

                    cellIndexList.AddFirst(cellHash);
                }

                if(cellIndexList.Count >= GameSetting.GameFieldSizeX)
                {
                    IsWin = true;
                    break;
                }
            }

            if (IsWin)
            {
                _gameUpdateCellIndexList = cellIndexList;
                ConectorMVC.UpdateController<GameScreenController>();
            }
            else
            {
                ConectorMVC.UpdateController<GameResultController>();
            }
        }

        private void Save()
        {
            using(var data = new GameFieldSaveStateData(_gameFieldStateTable.Count))
            {
                var index = 0;

                foreach(var el in _gameFieldStateTable)
                {
                    data.usedGameFieldCellIndex[index++] = el.Key;
                }

                PlayerPrefs.SetString(nameof(GameService), JsonUtility.ToJson(data));
            }
        }

        private void Load()
        {
            if (!PlayerPrefs.HasKey(nameof(GameService)))
            {                
                AddItem(01, false);
                AddItem(21, false);
                AddItem(100, false);
                return;
            }

            using (var data = JsonUtility.FromJson<GameFieldSaveStateData>(PlayerPrefs.GetString(nameof(GameService))))
            {
                for(var i = 0; i < data.usedGameFieldCellIndex.Length; ++i)
                {
                    AddItem(data.usedGameFieldCellIndex[i], false);
                }
            }
        }
    }
}

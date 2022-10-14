using System;
using System.Collections.Generic;
using UnityEngine;

using Code.GUI.MVC;
using Code.GUI.MVC.Controller;
using Code.GUI.Screens.GameResult;
using Code.GUI.Elements;
using Code.Locator;
using Code.Service;

namespace Code.GUI.Screens.Game
{
    public sealed class GameScreenController : BaseUpdatableController<GameScreen, GameScreenModel>
    {
        public override string Tag => nameof(GameScreenController);

        private event Action OnUpdateItemCell;

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.ViewObject.SetActive(Model.GameService.IsPlay);
            LinkedView.CanvasGroup.blocksRaycasts = !Model.GameService.IsWin;
            OnUpdateItemCell?.Invoke();

            Model.Update();
        }

        protected override void OnShow()
        {
            for (var y = 0; y < Model.GameService.GameSetting.GameFieldSizeY; ++y)
            {
                for (var x = 0; x < Model.GameService.GameSetting.GameFieldSizeX; ++x)
                {
                    CreateCell(
                        Model.TableItemCellElementPrefab, 
                        LinkedView.TableRoot, 
                        ConvertToHash(x, y));
                }
            }
            
            CreatePocketCell(LinkedView.SmallPocketRoot, Model.GameService.GameSetting.SmallPocketCount, 100);
            CreatePocketCell(LinkedView.BigPocketRoot, Model.GameService.GameSetting.BigPocketCount, 200);
            LinkedView.ResetDragAndDropElement.OnReset += ServiceLocator.Get<PlayerInputService>().OnResetHandling;

            UpdateView();            
        }

        private int ConvertToHash(int x, int y) => x * 10 + y;

        private void CreatePocketCell(Transform root, int count, int pocketHash)
        {
            for(var i = 0; i < count; ++i)
                CreateCell(Model.PocketItemCellElementPrefab, root, pocketHash + i);
        }

        private void CreateCell(in ItemCellElement cellPrototype, Transform root, int cellHash)
        {
            var playerInputService = ServiceLocator.Get<PlayerInputService>();
            var cell = Model.GameResourcesService.Create(cellPrototype);
            cell.transform.SetParent(root);
            cell.transform.localScale = Vector3.one;
            cell.InImage.enabled = false;
            cell.CellIndex = cellHash;

            cell.OnStartDrag += playerInputService.OnStartDragHandling;
            cell.OnProcessDrag += playerInputService.OnDragHandling;
            cell.OnEndDrag += playerInputService.OnEndDragHandling;

            OnUpdateItemCell += () => OnUpdateViewHandling(cell);
        }

        private void OnUpdateViewHandling(ItemCellElement cell)
        {
            if (Model.UpdateViewData.updateCellTable.TryGetValue(cell.CellIndex, out var status))
            {
                cell.InImage.enabled = status;
                switch (Model.UpdateViewData.UpdateStateType)
                {
                    case Data.UpdateStateType.Win:
                        Model.cellOnUpdateCount++;
                        LasyGameUpdater.Instance.EnableUpdate(cell, () => FloatHideHandling(cell));
                        break;
                }                
            }
        }

        private void FloatHideHandling(ItemCellElement cell)
        {
            cell.InImage.color = Color.Lerp(cell.InImage.color, Color.clear, 2 * Time.deltaTime);

            if(cell.InImage.color.a <= 0.075f)
            {
                Model.cellOnUpdateCount--;

                cell.InImage.color = Color.white;
                cell.InImage.enabled = false;

                LasyGameUpdater.Instance.DisableUpdate(cell);

                if(Model.cellOnUpdateCount <= 0)
                    ConectorMVC.UpdateController<GameResultController>();
            }
        }
    }
}

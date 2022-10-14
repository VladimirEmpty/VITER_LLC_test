using UnityEngine;

using Code.GUI.Elements;
using Code.GUI.Elements.DragItemView;
using Code.GUI.Screens.Game;
using Code.GUI.MVC;
using Code.Locator;

namespace Code.Service
{
    public sealed class PlayerInputService : IService
    {
        private readonly GameService GameService;

        private ItemCellElement _fromCellElement;

        public PlayerInputService()
        {
            GameService = ServiceLocator.Get<GameService>();
        }

        public Vector3 DragPosition
        {
            get
            {
                return Input.mousePosition;
            }
        }
        public bool IsDraged { get; private set; }

        public void OnStartDragHandling(ItemCellElement itemCellElement)
        {
            if (!GameService.IsContainItem(itemCellElement.CellIndex)) return;

            _fromCellElement = itemCellElement;
            IsDraged = true;

            GameService.RemoveItem(itemCellElement.CellIndex);

            ConectorMVC.UpdateController<GameScreenController>();
            ConectorMVC.UpdateController<DragItemViewElementController>();
        }

        public void OnDragHandling()
        {
            if (!IsDraged) return;

            ConectorMVC.UpdateController<DragItemViewElementController>();
        }

        public void OnEndDragHandling(ItemCellElement itemCellElement)
        {
            if (!IsDraged) return;

            GameService.AddItem(
                           GameService.IsContainItem(itemCellElement.CellIndex)
                                       ? _fromCellElement.CellIndex
                                       : itemCellElement.CellIndex
                              );

            _fromCellElement = null;
            IsDraged = false;
            
            ConectorMVC.UpdateController<GameScreenController>();
            ConectorMVC.UpdateController<DragItemViewElementController>();
        }

        public void OnResetHandling()
        {
            if (IsDraged)
            {
                GameService.AddItem(_fromCellElement.CellIndex);
            }

            _fromCellElement = null;
            IsDraged = false;

            ConectorMVC.UpdateController<GameScreenController>();
            ConectorMVC.UpdateController<DragItemViewElementController>();
        }
    }
}

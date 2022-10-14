using UnityEngine;
using Code.Locator;
using Code.Service;
using Code.GUI.MVC.Model;

namespace Code.GUI.Elements.DragItemView
{
    public sealed class DragItemViewElementModel : IModel
    {
        private readonly PlayerInputService PlayerInputService;

        public DragItemViewElementModel()
        {
            PlayerInputService = ServiceLocator.Get<PlayerInputService>();
        }

        public Vector3 DragPosition { get; private set; }
        public bool IsShowed { get; private set; }

        public void Request()
        {
            DragPosition = PlayerInputService.DragPosition;
            IsShowed = PlayerInputService.IsDraged;
        }

        public void Update()
        {
        }
    }
}

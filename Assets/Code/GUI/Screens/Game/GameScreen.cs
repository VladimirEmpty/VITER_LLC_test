using UnityEngine;

using Code.GUI.MVC;
using Code.GUI.MVC.View;
using Code.GUI.Elements;

namespace Code.GUI.Screens.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class GameScreen : MonoBehaviour, IView
    {
        [SerializeField] private ResetDragAndDropElement _resetDragAndDropElement;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _viewObject;
        [SerializeField] private Transform _tableRoot;
        [SerializeField] private Transform _smallPocketRoot;
        [SerializeField] private Transform _bigPocketRoot;

        public ResetDragAndDropElement ResetDragAndDropElement => _resetDragAndDropElement;
        public CanvasGroup CanvasGroup => _canvasGroup;
        public GameObject ViewObject => _viewObject;
        public Transform TableRoot => _tableRoot;
        public Transform SmallPocketRoot => _smallPocketRoot;
        public Transform BigPocketRoot => _bigPocketRoot;

        private void Start()
        {
            this.AddController<GameScreenController>();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

using Code.GUI.MVC;
using Code.GUI.MVC.View;

namespace Code.GUI.Screens.StartGame
{
    public sealed class StartGameScreen : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _viewObject;
        [SerializeField] private Button _startGameButton;

        public GameObject ViewObject => _viewObject;
        public Button StartGameButton => _startGameButton;

        private void Start()
        {
            this.AddController<StartGameScreenController>();
        }
    }
}

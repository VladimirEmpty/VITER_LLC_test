using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Code.GUI.MVC;
using Code.GUI.MVC.View;

namespace Code.GUI.Screens.GameResult
{
    public sealed class GameResultScreen : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _viewObject;
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private Button _restartButton;

        public GameObject ViewObject => _viewObject;
        public TextMeshProUGUI ResultText => _resultText;
        public Button RestartButton => _restartButton;


        private void Start()
        {
            this.AddController<GameResultController>();
        }
    }
}

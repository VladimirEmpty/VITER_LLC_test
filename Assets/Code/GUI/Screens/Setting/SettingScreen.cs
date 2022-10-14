using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Code.GUI.MVC;
using Code.GUI.MVC.View;

namespace Code.GUI.Screens.Setting
{
    public sealed class SettingScreen : MonoBehaviour, IView
    {
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private GameObject _viewObject;
        [SerializeField] private TextMeshProUGUI _soundValueText;

        public Button SettingButton => _settingButton;
        public Button CloseButton => _closeButton;
        public Slider SoundSlider => _soundSlider;
        public GameObject ViewObject => _viewObject;
        public TextMeshProUGUI SoundValueText => _soundValueText;

        private void Start()
        {
            this.AddController<SettingScreenController>();
        }
    }
}

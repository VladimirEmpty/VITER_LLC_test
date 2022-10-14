using Code.GUI.MVC.Controller;

namespace Code.GUI.Screens.Setting
{
    public sealed class SettingScreenController : BaseUpdatableController<SettingScreen, SettingScreenModel>
    {
        public override string Tag => nameof(SettingScreenController);

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.SoundSlider.value = Model.soundValue;
            ChangeSoundText(Model.soundValue);
        }

        protected override void OnShow()
        {
            LinkedView.ViewObject.SetActive(false);
            LinkedView.SettingButton.onClick.AddListener(() =>
            {
                LinkedView.ViewObject.SetActive(true);
                UpdateView();
            });

            LinkedView.CloseButton.onClick.AddListener(() =>
            {
                LinkedView.ViewObject.SetActive(false);
            });

            LinkedView.SoundSlider.minValue = Model.MinSoundValue;
            LinkedView.SoundSlider.maxValue = Model.MaxSoundValue;
            LinkedView.SoundSlider.onValueChanged.AddListener(value =>
            {
                ChangeSoundText(value);
                Model.soundValue = value;
                Model.Update();
            });

            UpdateView();
        }

        private void ChangeSoundText(float value)
        {
            LinkedView.SoundValueText.text = $"{value.ToString("00")} %";
        }
    }
}

using UnityEngine;

using Code.GUI.MVC.Model;

namespace Code.GUI.Screens.Setting
{
    public sealed class SettingScreenModel : IModel
    {
        public float soundValue;

        public float MinSoundValue => 0f;
        public float MaxSoundValue => 100f;

        public void Request()
        {
            soundValue = PlayerPrefs.GetFloat(nameof(soundValue), 25);   
        }

        public void Update()
        {
            PlayerPrefs.SetFloat(nameof(soundValue), soundValue);
        }
    }
}

using UnityEngine;

using Code.Locator;
using Code.Service;
using Code.Setting;

using Code.GUI.MVC;
using Code.GUI.Screens.Game;

namespace Code
{
    public sealed class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameSetting _gameSetting;
        [SerializeField] private GameResourcesSetting _gameResourcesSetting;

        private void Reset()
        {
            gameObject.name = nameof(GameInstaller);
        }

        private void Awake()
        {
            ServiceLocator.Add(new GameService(_gameSetting));
            ServiceLocator.Add(new GameResourcesService(_gameResourcesSetting));
            ServiceLocator.Add<PlayerInputService>();
        }
    }
}

using Code.GUI.MVC.Model;
using Code.Locator;
using Code.Service;

namespace Code.GUI.Screens.StartGame
{
    public sealed class StartGameScreenModel : IModel
    {
        private readonly GameService GameService;

        public StartGameScreenModel()
        {
            GameService = ServiceLocator.Get<GameService>();
        }

        public void Request()
        {            
        }

        public void Update()
        {
            GameService.StatGame();
        }
    }
}

using Code.GUI.MVC.Model;
using Code.Locator;
using Code.Service;

namespace Code.GUI.Screens.GameResult
{
    public sealed class GameResultModel : IModel
    {
        private readonly GameService GameService;
        
        public GameResultModel()
        {
            GameService = ServiceLocator.Get<GameService>();
        }

        public string ResultMessage { get; private set; }

        public void Request()
        {
            ResultMessage = GameService.IsWin
                                        ? "WIN"
                                        : "LOSE";
        }

        public void Update()
        {
            //resetart game
            GameService.EndGame();
        }
    }
}

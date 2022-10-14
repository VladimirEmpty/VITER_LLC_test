using Code.GUI.MVC.Controller;

namespace Code.GUI.Screens.StartGame
{
    public sealed class StartGameScreenController : BaseUpdatableController<StartGameScreen, StartGameScreenModel>
    {
        public override string Tag => nameof(StartGameScreenController);

        public override void UpdateView()
        {
            LinkedView.ViewObject.SetActive(true);
        }

        protected override void OnShow()
        {
            LinkedView.ViewObject.SetActive(true);
            LinkedView.StartGameButton.onClick.AddListener(() =>
            {
                LinkedView.ViewObject.SetActive(false);
                Model.Update();
            });
        }
    }
}

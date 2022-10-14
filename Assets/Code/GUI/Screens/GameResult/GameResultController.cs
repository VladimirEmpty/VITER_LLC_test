using Code.GUI.MVC.Controller;

namespace Code.GUI.Screens.GameResult
{
    public sealed class GameResultController : BaseUpdatableController<GameResultScreen, GameResultModel>
    {
        public override string Tag => nameof(GameResultController);

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.ViewObject.SetActive(true);
            LinkedView.ResultText.text = Model.ResultMessage;
        }

        protected override void OnShow()
        {
            LinkedView.ViewObject.SetActive(false);
            LinkedView.RestartButton.onClick.AddListener(() =>
            {
                LinkedView.ViewObject.SetActive(false);
                Model.Update();
            });
        }
    }
}

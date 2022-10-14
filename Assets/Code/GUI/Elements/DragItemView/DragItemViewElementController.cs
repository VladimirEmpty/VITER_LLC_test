using Code.GUI.MVC.Controller;

namespace Code.GUI.Elements.DragItemView
{
    public sealed class DragItemViewElementController : BaseUpdatableController<DragItemViewElement, DragItemViewElementModel>
    {
        public override string Tag => nameof(DragItemViewElementController);

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.ItemImage.enabled = Model.IsShowed;
            LinkedView.transform.position = Model.DragPosition;
        }

        protected override void OnShow()
        {
            LinkedView.ItemImage.enabled = false;
        }
    }
}

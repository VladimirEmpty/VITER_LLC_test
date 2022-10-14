using UnityEngine;
using UnityEngine.UI;

using Code.GUI.MVC;
using Code.GUI.MVC.View;

namespace Code.GUI.Elements.DragItemView
{
    [RequireComponent(typeof(Image))]
    public sealed class DragItemViewElement : MonoBehaviour, IView
    {
        public Image ItemImage { get; private set; }        

        private void Start()
        {
            ItemImage = GetComponent<Image>();
            this.AddController<DragItemViewElementController>();
        }
    }
}

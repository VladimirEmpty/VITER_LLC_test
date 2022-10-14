using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Code.GUI.Elements
{
    public sealed class ItemCellElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler
    {
        [SerializeField] private Image _inImage;

        public Image InImage => _inImage;
        public int CellIndex { get; set; }

        public event Action<ItemCellElement> OnStartDrag;
        public event Action OnProcessDrag;
        public event Action<ItemCellElement> OnEndDrag;

        public void OnBeginDrag(PointerEventData eventData) => OnStartDrag?.Invoke(this);

        public void OnDrag(PointerEventData eventData) => OnProcessDrag?.Invoke();

        public void OnDrop(PointerEventData eventData) => OnEndDrag?.Invoke(this);
    }
}

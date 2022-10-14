using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Code.GUI.Elements
{
    [RequireComponent(typeof(Image))]
    public sealed class ResetDragAndDropElement : MonoBehaviour, IDropHandler
    {
        public event Action OnReset;

        public void OnDrop(PointerEventData eventData) => OnReset?.Invoke();
    }
}

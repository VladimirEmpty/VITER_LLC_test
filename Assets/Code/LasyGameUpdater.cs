using System;
using System.Collections.Generic;
using UnityEngine;

using TargetObejct = UnityEngine.Object;

namespace Code
{
    public sealed class LasyGameUpdater : MonoBehaviour
    {
        private IDictionary<int, Action> _onUpdateActionTable = new Dictionary<int, Action>();
        public static LasyGameUpdater Instance { get; private set; }

        public event Action OnUpdate;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            Instance = new GameObject(nameof(LasyGameUpdater)).AddComponent<LasyGameUpdater>();
        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        public void EnableUpdate(TargetObejct targetObject, Action onUpdateCallback)
        {
            _onUpdateActionTable[targetObject.GetHashCode()] = onUpdateCallback;
            OnUpdate += onUpdateCallback;
        }

        public void DisableUpdate(TargetObejct targetObject)
        {
            if(_onUpdateActionTable.TryGetValue(targetObject.GetHashCode(), out var onUpdateCallback))
            {
                OnUpdate -= onUpdateCallback;
                _onUpdateActionTable.Remove(targetObject.GetHashCode());
            }
        }
    }
}

using UnityEngine;

using Code.GUI.Elements;

namespace Code.Setting
{
    [CreateAssetMenu(fileName = nameof(GameResourcesSetting), menuName = "Setting/GameResources")]
    public sealed class GameResourcesSetting : ScriptableObject
    {
        [SerializeField] private ItemCellElement _tableItemCellElementPrefab;
        [SerializeField] private ItemCellElement _pocketItemCellElementPrefab;


        public ItemCellElement TableItemCellElementPrefab => _tableItemCellElementPrefab;
        public ItemCellElement PocketItemCellElementPrefab => _pocketItemCellElementPrefab;
    }
}

using Code.GUI.MVC.Model;
using Code.GUI.Elements;
using Code.Locator;
using Code.Service;
using Code.Data;

namespace Code.GUI.Screens.Game
{
    public sealed class GameScreenModel : IModel
    {
        public int cellOnUpdateCount;

        public GameScreenModel()
        {
            GameService = ServiceLocator.Get<GameService>();
            GameResourcesService = ServiceLocator.Get<GameResourcesService>();

            PocketItemCellElementPrefab = GameResourcesService.GameResourcesSetting.PocketItemCellElementPrefab;
            TableItemCellElementPrefab = GameResourcesService.GameResourcesSetting.TableItemCellElementPrefab;
        }

        public GameService GameService { get; }
        public GameResourcesService GameResourcesService { get; }
        public ItemCellElement TableItemCellElementPrefab { get; }
        public ItemCellElement PocketItemCellElementPrefab { get; }

        public GameFieldUpdateViewItemData UpdateViewData { get; private set; }

        public void Request()
        {
            UpdateViewData = GameService.GetUpdateViewItemData();
        }

        public void Update()
        {
            UpdateViewData.Dispose();
        }
    }
}

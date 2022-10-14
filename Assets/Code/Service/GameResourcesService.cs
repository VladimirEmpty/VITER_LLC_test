using UnityEngine;

using Code.Factory;
using Code.Setting;

namespace Code.Service
{
    public sealed class GameResourcesService : IService
    {
        public GameResourcesService(GameResourcesSetting gameResourcesSetting)
        {
            GameResourcesSetting = gameResourcesSetting;
        }

        public GameResourcesSetting GameResourcesSetting { get; }

        public T Create<T>(T prototype)
            where T : Object
        {
            using(var factory = new GameObjectFactory<T>(prototype))
            {
                return factory.Create();
            }
        }
    }
}

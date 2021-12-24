using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.Systems
{
    public class CreatePlayerSystem : IInitializeSystem
    {
        private Contexts _contexts;
        private GameObject _playerObject;

        public CreatePlayerSystem(Contexts contexts, GameObject playerObject)
        {
            _contexts = contexts;
            _playerObject = playerObject;
        }

        public void Initialize()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddView(_playerObject);
            entity.AddPosition(_playerObject.transform.position);
            entity.AddSpeed(10);
            _playerObject.Link(entity);
        }
    }
}
using Entitas;
using Entitas.Unity;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class CreatePlayerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly GameObject _playerObject;
        private readonly GameSettings _gameSettings;

        public CreatePlayerSystem(Contexts contexts, GameObject playerObject, GameSettings gameSettings)
        {
            _contexts = contexts;
            _playerObject = playerObject;
            _gameSettings = gameSettings;
        }

        public void Initialize()
        {
            var entity = _contexts.game.CreateEntity();
            entity.isPlayer = true;
            entity.isAlive = true;
            entity.AddView(_playerObject);
            entity.AddPosition(_playerObject.transform.position);
            entity.AddTarget(null);
            entity.AddSpeed(_gameSettings.player.speed);
            entity.AddMovementDirection(Vector3.zero);
            entity.AddAnimation(_playerObject.GetComponent<Animator>());
            _playerObject.Link(entity);
        }
    }
}
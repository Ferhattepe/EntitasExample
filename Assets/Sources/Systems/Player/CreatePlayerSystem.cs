using Entitas;
using Entitas.Unity;
using Sources.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Systems
{
    public class CreatePlayerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly GameObject _playerObject;
        private readonly GameSettings _gameSettings;
        private readonly Slider _healthSlider;
        private readonly Transform _bulletSpawnPoint;

        public CreatePlayerSystem(Contexts contexts, GameObject playerObject, Slider healthSlider,
            Transform bulletSpawnPoint,
            GameSettings gameSettings)
        {
            _contexts = contexts;
            _bulletSpawnPoint = bulletSpawnPoint;
            _playerObject = playerObject;
            _gameSettings = gameSettings;
            _healthSlider = healthSlider;
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
            entity.AddBaseHealth(_gameSettings.player.baseHealth);
            entity.AddCurrentHealth(_gameSettings.player.baseHealth);
            entity.AddHealthView(_healthSlider);
            entity.AddAttackData(_gameSettings.player.attackInterval, _gameSettings.player.attackRange,
                _gameSettings.player.attackDelay);
            entity.AddNextAttackTime(Time.time + _gameSettings.player.attackInterval);
            entity.AddBulletSpawnPoint(_bulletSpawnPoint);
            _playerObject.Link(entity);
        }
    }
}
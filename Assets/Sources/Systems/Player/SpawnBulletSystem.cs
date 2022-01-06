using Entitas;
using Entitas.Unity;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class SpawnBulletSystem : IExecuteSystem, ICleanupSystem
    {
        private IGroup<GameEntity> _group;
        private GameContext _game;
        private GameSettings _settings;

        public SpawnBulletSystem(Contexts contexts, GameSettings settings)
        {
            _group = contexts.game.GetGroup(GameMatcher.FireBullet);
            _game = contexts.game;
            _settings = settings;
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var bulletEntity = _game.CreateEntity();
                var spawnPointTransform = entity.bulletSpawnPoint.Value;
                var direction = entity.fireBullet.Direction;
                var bulletObject = GameObject.Instantiate(_settings.player.gun.bulletPrefab,
                    spawnPointTransform.position,
                    spawnPointTransform.rotation);
                bulletObject.transform.forward = direction;
                bulletEntity.AddView(bulletObject);
                bulletEntity.AddMovementDirection(direction);
                bulletEntity.AddSpeed(_settings.player.gun.speed);
                bulletEntity.AddRigidbody(bulletObject.GetComponent<Rigidbody>());
                bulletObject.Link(bulletEntity);
            }
        }

        public void Cleanup()
        {
            foreach (var entity in _group.GetEntities())
            {
                entity.RemoveFireBullet();
            }
        }
    }
}
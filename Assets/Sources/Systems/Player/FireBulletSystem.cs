using Entitas;
using Entitas.Unity;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class FireBulletSystem : IExecuteSystem, ICleanupSystem
    {
        private IGroup<GameEntity> _group;
        private GameContext _game;
        private GameSettings _settings;

        public FireBulletSystem(Contexts contexts, GameSettings settings)
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
                var bulletObject = GameObject.Instantiate(_settings.player.gun.bulletPrefab,
                    spawnPointTransform.position,
                    spawnPointTransform.rotation);
                bulletEntity.AddView(bulletObject);
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
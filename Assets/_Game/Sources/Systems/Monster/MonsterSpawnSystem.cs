using Entitas;
using Entitas.Unity;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class MonsterSpawnSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly GameSettings _settings;
        private readonly Transform _spawnPoint;

        public MonsterSpawnSystem(Contexts contexts, Transform spawnPoint, GameSettings settings)
        {
            _contexts = contexts;
            _settings = settings;
            _spawnPoint = spawnPoint;
        }

        public void Initialize()
        {
            _contexts.game.CreateEntity().AddMonsterSpawn(Time.time);
        }

        public void Execute()
        {
            if (_contexts.game.monsterSpawn.NextSpawnTime <= Time.time)
            {
                var view = GameObject.Instantiate(_settings.monster.prefab, _spawnPoint);
                var entity = _contexts.game.CreateEntity();
                entity.isMonster = true;
                entity.isAlive = true;
                entity.AddView(view);
                entity.AddRigidbody(view.GetComponent<Rigidbody>());
                entity.AddVelocityLimit(_settings.monster.velocityLimit);
                entity.AddTarget(null);
                entity.AddAttackData(_settings.monster.attackInterval, _settings.monster.attackRange,
                    _settings.monster.attackDelay);
                entity.AddNextAttackTime(Time.time + _settings.monster.attackInterval);
                entity.AddMovementDirection(Vector3.zero);
                entity.AddSpeed(_settings.monster.speed);
                entity.AddBaseHealth(_settings.monster.baseHealth);
                entity.AddCurrentHealth(_settings.monster.baseHealth);
                view.Link(entity);
                _contexts.game.monsterSpawn.NextSpawnTime = Time.time + _settings.monster.spawnInterval;
            }
        }
    }
}
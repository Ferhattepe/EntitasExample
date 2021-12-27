using Entitas;
using Entitas.Unity;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class MonsterSpawnSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly Contexts _contexts;
        private readonly GameSettings _gameSettings;
        private readonly Transform _spawnPoint;

        public MonsterSpawnSystem(Contexts contexts, Transform spawnPoint, GameSettings gameSettings)
        {
            _contexts = contexts;
            _gameSettings = gameSettings;
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
                var view = GameObject.Instantiate(_gameSettings.monster.prefab, _spawnPoint);
                var entity = _contexts.game.CreateEntity();
                entity.isMonster = true;
                entity.AddView(view);
                entity.AddRigidbody(view.GetComponent<Rigidbody>());
                entity.AddVelocityLimit(_gameSettings.monster.velocityLimit);
                entity.AddMovementDirection(Vector3.zero);
                entity.AddSpeed(_gameSettings.monster.speed);
                view.Link(entity);
                _contexts.game.monsterSpawn.NextSpawnTime = Time.time + _gameSettings.monster.spawnInterval;
            }
        }
    }
}
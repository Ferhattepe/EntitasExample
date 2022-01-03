using Entitas;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class FindNearliestMonsterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _monsters;
        private readonly IGroup<GameEntity> _player;
        private GameSettings _settings;

        public FindNearliestMonsterSystem(Contexts contexts, GameSettings settings)
        {
            _settings = settings;
            _monsters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Monster, GameMatcher.Alive));
            _player = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Alive));
        }

        public void Execute()
        {
            var monsters = _monsters.GetEntities();
            foreach (var playerEntity in _player.GetEntities())
            {
                var minDistance = _settings.player.detectionDistance;
                Transform nearliestTarget = null;
                foreach (var monsterEntity in monsters)
                {
                    var distance = Vector3.Distance(monsterEntity.view.Value.transform.position
                        , playerEntity.view.Value.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearliestTarget = monsterEntity.view.Value.transform;
                    }
                }

                if (nearliestTarget != playerEntity.playerTarget.Value)
                    playerEntity.ReplacePlayerTarget(nearliestTarget);
            }
        }
    }
}
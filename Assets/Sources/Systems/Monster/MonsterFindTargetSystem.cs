using Entitas;
using Sources.Settings;
using Sources.Utility;
using UnityEngine;

namespace Sources.Systems
{
    public class MonsterFindTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _monsters;
        private readonly IGroup<GameEntity> _targets;
        private GameSettings _settings;
        private Repeater _repeater;

        public MonsterFindTargetSystem(Contexts contexts, GameSettings settings)
        {
            _settings = settings;
            _monsters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Monster, GameMatcher.Target,
                GameMatcher.Alive));
            _targets = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Alive));
            _repeater = new Repeater();
        }

        public void Execute()
        {
            if (_repeater.Set(_settings.monster.detectionInterval))
            {
                var targets = _targets.GetEntities();

                foreach (var entity in _monsters.GetEntities())
                {
                    GameEntity nearliestTarget = null;
                    var minDistance = float.MaxValue;
                    foreach (var target in targets)
                    {
                        var distance = Vector3.Distance(target.view.Value.transform.position,
                            entity.view.Value.transform.position);
                        if (distance <= minDistance)
                        {
                            minDistance = distance;
                            nearliestTarget = target;
                        }
                    }

                    entity.ReplaceTarget(nearliestTarget);
                }
            }
        }
    }
}
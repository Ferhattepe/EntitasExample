using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MonsterNavmeshSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _monsters;
        private readonly IGroup<GameEntity> _targets;

        public MonsterNavmeshSystem(Contexts contexts)
        {
            _monsters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MovementDirection, GameMatcher.Monster,
                GameMatcher.View));
            _targets = contexts.game.GetGroup(GameMatcher.MonsterTarget);
        }

        public void Execute()
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

                if (nearliestTarget != null)
                {
                    var direction =
                        (nearliestTarget.view.Value.transform.position - entity.view.Value.transform.position)
                        .normalized;
                    direction.y = 0;
                    entity.ReplaceMovementDirection(direction);
                }
                else
                {
                    entity.ReplaceMovementDirection(Vector3.zero);
                }
            }
        }
    }
}
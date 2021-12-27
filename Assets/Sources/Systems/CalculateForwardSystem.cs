using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class CalculateForwardSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public CalculateForwardSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MovementDirection, GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var direction = entity.movementDirection.Value;
                if (direction != Vector3.zero)
                    entity.view.Value.transform.forward = direction;
            }
        }
    }
}
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class PhysicsVelocityLimitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public PhysicsVelocityLimitSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Rigidbody, GameMatcher.VelocityLimit));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                // Debug.LogError($"Before {entity.rigidbody.Value.velocity.magnitude}");
                entity.rigidbody.Value.velocity =
                    Vector3.ClampMagnitude(entity.rigidbody.Value.velocity, entity.velocityLimit.Value);
                // Debug.LogError($"After {entity.rigidbody.Value.velocity.magnitude}");
            }
        }
    }
}
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class PhysicsMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public PhysicsMoveSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MovementDirection, GameMatcher.Rigidbody,
                GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var direction = entity.movementDirection.Value;
                entity.rigidbody.Value.position += direction * entity.speed.Value * Time.fixedDeltaTime;
                // entity.rigidbody.Value.AddForce(direction * entity.speed.Value);
            }
        }
    }
}
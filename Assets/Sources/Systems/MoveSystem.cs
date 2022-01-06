using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public MoveSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Alive, GameMatcher.MovementDirection,
                GameMatcher.Position,
                GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var direction = entity.movementDirection.Value;
                var value = entity.position.Value +
                            direction * entity.speed.Value * Time.deltaTime;
                entity.ReplacePosition(value);
            }
        }
    }
}
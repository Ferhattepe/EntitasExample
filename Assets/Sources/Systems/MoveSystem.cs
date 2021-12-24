using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MoveSystem : IExecuteSystem
    {
        private GameContext _contexts;
        private IGroup<GameEntity> _group;

        public MoveSystem(Contexts contexts)
        {
            _contexts = contexts.game;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (var e in _group.GetEntities())
            {
                var value = e.position.value + _contexts.movementDirection.value * e.speed.value * Time.deltaTime;
                e.ReplacePosition(value);
            }
        }
    }
}
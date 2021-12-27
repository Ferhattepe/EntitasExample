using Entitas;

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
                entity.rigidbody.Value.AddForce(direction * entity.speed.Value);
            }
        }
    }
}
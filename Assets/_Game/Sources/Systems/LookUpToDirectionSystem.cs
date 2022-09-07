using Entitas;

namespace Sources.Systems
{

    public class LookUpToDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public LookUpToDirectionSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Monster, GameMatcher.Alive, GameMatcher.MovementDirection));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var direction = entity.movementDirection.Value;
                entity.view.Value.transform.forward = direction;
            }
        }
    }
}
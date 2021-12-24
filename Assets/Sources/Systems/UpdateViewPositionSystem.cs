using System.Collections.Generic;
using Entitas;

namespace Sources.Systems
{
    public class UpdateViewPositionSystem : ReactiveSystem<GameEntity>
    {
        public UpdateViewPositionSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                e.view.value.transform.position = e.position.value;
            }
        }
    }
}
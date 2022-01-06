using System.Collections.Generic;
using Entitas;

namespace Sources.Systems
{
    public class CheckDeathSystem : ReactiveSystem<GameEntity>
    {
        public CheckDeathSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CurrentHealth);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isAlive;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.currentHealth.Value <= 0)
                {
                    entity.isAlive = false;
                }
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace Sources.Systems.Monster
{
    public class MonsterBeginAttackStateSystem : ReactiveSystem<GameEntity>
    {
        public MonsterBeginAttackStateSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AttackState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isMonster && entity.hasMovementDirection;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.RemoveMovementDirection();
            }
        }
    }
}
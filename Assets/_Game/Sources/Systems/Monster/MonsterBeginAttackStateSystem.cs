using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems.Monster
{
    public class MonsterBeginAttackStateSystem : ReactiveSystem<GameEntity>
    {
        public MonsterBeginAttackStateSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Attack);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isMonster && entity.isAttack;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Debug.LogError("AttackExecute");
                entity.isRun = false;
                entity.RemoveMovementDirection();
            }
        }
    }
}
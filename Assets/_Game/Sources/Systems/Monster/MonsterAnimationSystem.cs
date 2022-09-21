using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems.Monster
{
    public class MonsterAnimationSystem : ReactiveSystem<GameEntity>
    {
        public MonsterAnimationSystem(Contexts context) : base(context.game)
        {
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Run);
        }
        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Debug.LogError($"Execute {entity.isRun}");
                if (entity.isRun)
                    entity.animation.Value.SetTrigger("run");
                else
                    entity.animation.Value.SetTrigger("idle");
            }
        }
    }
}
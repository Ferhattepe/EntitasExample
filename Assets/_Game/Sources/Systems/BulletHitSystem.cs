using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class BulletHitSystem : ReactiveSystem<GameEntity>, ICleanupSystem
    {
        private readonly IGroup<GameEntity> _triggerEntities;

        public BulletHitSystem(Contexts contexts) : base(contexts.game)
        {
            _triggerEntities = contexts.game.GetGroup(GameMatcher.Trigger);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Trigger);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.trigger.Self.view.Value.CompareTag("Bullet");
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var target = entity.trigger.Other;
                if (target.hasCurrentHealth)
                    target.ReplaceCurrentHealth(target.currentHealth.Value - 1);
            }
        }

        public void Cleanup()
        {
            foreach (var entity in _triggerEntities.GetEntities())
            {
                if (entity.trigger.Self.view.Value.CompareTag("Bullet"))
                {
                    entity.trigger.Self.Destroy();
                    entity.Destroy();
                }
            }
        }
    }
}
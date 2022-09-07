using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class ProgressCollisionSystem : ReactiveSystem<InputEntity>, ICleanupSystem
    {
        private readonly IGroup<InputEntity> _collisionEntities;

        public ProgressCollisionSystem(Contexts contexts) : base(contexts.input)
        {
            _collisionEntities = contexts.input.GetGroup(InputMatcher.Collision);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.Collision);
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
            {
                Debug.LogError($"Collision {entity.collision.Self} {entity.collision.Other}");
            }
        }

        public void Cleanup()
        {
            foreach (var entity in _collisionEntities.GetEntities())
            {
                entity.Destroy();
            }
        }
    }
}
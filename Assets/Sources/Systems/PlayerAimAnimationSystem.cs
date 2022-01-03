using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class PlayerAimAnimationSystem : ReactiveSystem<GameEntity>
    {
        private static readonly int AimKey = Animator.StringToHash("aim");

        public PlayerAimAnimationSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Target,
                GameMatcher.Animation));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isAlive;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isAim = entity.target.Value != null;
                entity.animation.Value.SetBool(AimKey, entity.isAim);
            }
        }
    }
}
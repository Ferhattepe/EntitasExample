using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Systems
{
    public class UpdateHealthViewComponent : ReactiveSystem<GameEntity>
    {
        public UpdateHealthViewComponent(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.BaseHealth, GameMatcher.CurrentHealth));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHealthView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.healthView.Slider.maxValue = entity.baseHealth.Value;
                entity.healthView.Slider.minValue = 0;
                entity.healthView.Slider.value = entity.currentHealth.Value;
            }
        }
    }
}
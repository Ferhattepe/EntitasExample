using System.Collections.Generic;
using Entitas;

namespace Sources.Systems
{
    public class PlayerJoystickControlSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;
        private readonly IGroup<GameEntity> _group;

        public PlayerJoystickControlSystem(Contexts contexts) : base(contexts.input)
        {
            _inputContext = contexts.input;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.MovementDirection));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.JoystickInput);
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in _group.GetEntities())
            {
                var direction = _inputContext.joystickInput.Value.normalized;
                entity.ReplaceMovementDirection(direction);
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MovementAnimationSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;
        private readonly IGroup<GameEntity> _group;
        private static readonly int VelocityX = Animator.StringToHash("VelocityX");
        private static readonly int VelocityZ = Animator.StringToHash("VelocityZ");
        private static readonly int Run = Animator.StringToHash("run");

        public MovementAnimationSystem(Contexts contexts) : base(contexts.input)
        {
            _inputContext = contexts.input;
            _group = contexts.game.GetGroup(GameMatcher.Player);
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
                var movementDirection = _inputContext.joystickInput.Value;
                entity.animation.Value.SetBool(Run, movementDirection.magnitude > 0f);
                var velocityZ = Vector3.Dot(movementDirection, entity.view.Value.transform.forward);
                var velocityX = Vector3.Dot(movementDirection, entity.view.Value.transform.right);
                entity.animation.Value.SetFloat(VelocityX, velocityX, 0.1f, Time.deltaTime);
                entity.animation.Value.SetFloat(VelocityZ, velocityZ, 0.1f, Time.deltaTime);
            }
        }
    }
}
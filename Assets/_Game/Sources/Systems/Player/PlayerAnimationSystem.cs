using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class PlayerAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private static readonly int VelocityX = Animator.StringToHash("VelocityX");
        private static readonly int VelocityZ = Animator.StringToHash("VelocityZ");
        private static readonly int RunKey = Animator.StringToHash("run");

        public PlayerAnimationSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.Player);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var movementDirection = entity.movementDirection.Value;
                var isRun = movementDirection.magnitude > 0;
                entity.animation.Value.SetBool(RunKey, isRun);
                var velocityZ = Vector3.Dot(movementDirection, entity.view.Value.transform.forward);
                var velocityX = Vector3.Dot(movementDirection, entity.view.Value.transform.right);
                entity.animation.Value.SetFloat(VelocityX, velocityX, 0.1f, Time.deltaTime);
                entity.animation.Value.SetFloat(VelocityZ, velocityZ, 0.1f, Time.deltaTime);
            }
        }
    }
}
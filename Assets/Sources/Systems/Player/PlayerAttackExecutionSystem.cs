using Entitas;
using UnityEngine;

namespace Sources.Systems.Player
{
    public class PlayerAttackExecutionSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;

        public PlayerAttackExecutionSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.AttackState,
                GameMatcher.AttackData,
                GameMatcher.Target));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.attackState.ExecutionTime <= Time.time)
                {
                    if (entity.target.Value != null)
                    {
                        var selfPosition = entity.view.Value.transform.position;
                        var targetPosition = entity.target.Value.view.Value.transform.position;
                        var distance = Vector3.Distance(targetPosition, selfPosition);

                        if (distance <= entity.attackData.Range)
                        {
                            var bulletDirection = targetPosition - entity.bulletSpawnPoint.Value.position;
                            bulletDirection.y = 0;
                            entity.AddFireBullet(bulletDirection.normalized);
                            entity.gunView.GunfireController.FireWeapon();
                        }
                    }
                }
            }
        }

        public void Cleanup()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.attackState.ExecutionTime <= Time.time)
                {
                    entity.RemoveAttackState();
                }
            }
        }
    }
}
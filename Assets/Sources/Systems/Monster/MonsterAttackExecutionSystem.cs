using Entitas;
using UnityEngine;
using DG.Tweening;
using Sources.Settings;

namespace Sources.Systems
{
    public class MonsterAttackExecutionSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;

        public MonsterAttackExecutionSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Monster, GameMatcher.AttackState,
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
                            var newHealthValue = entity.target.Value.currentHealth.Value - 1;
                            entity.target.Value.ReplaceCurrentHealth(newHealthValue);
                        }
                    }

                    entity.view.Value.transform.DOShakeScale(0.2f);
                    entity.AddMovementDirection(Vector3.zero);
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
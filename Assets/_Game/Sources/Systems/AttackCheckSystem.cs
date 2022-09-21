using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class AttackCheckSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public AttackCheckSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.NextAttackTime, GameMatcher.AttackData, GameMatcher.Target)
                .NoneOf(GameMatcher.Attack));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.target.Value == null) continue;
                var distance = Vector3.Distance(entity.target.Value.view.Value.transform.position,
                      entity.view.Value.transform.position);

                if (distance <= entity.attackData.Range)
                {
                    if (entity.nextAttackTime.Value <= Time.time)
                    {
                        entity.ReplaceNextAttackTime(Time.time + entity.attackData.Interval);
                        entity.isAttack = true;
                    }
                }
            }
        }
    }
}
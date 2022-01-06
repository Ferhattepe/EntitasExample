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
                .NoneOf(GameMatcher.AttackState));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.target.Value == null) continue;
                if (entity.nextAttackTime.Value <= Time.time)
                {
                    var distance = Vector3.Distance(entity.target.Value.view.Value.transform.position,
                        entity.view.Value.transform.position);
                    if (distance <= entity.attackData.Range)
                    {
                        entity.ReplaceNextAttackTime(Time.time + entity.attackData.Interval);
                        entity.AddAttackState(Time.time + entity.attackData.AttackDelay);
                    }
                }
            }
        }
    }
}
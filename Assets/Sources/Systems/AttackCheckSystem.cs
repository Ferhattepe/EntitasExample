using Entitas;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class AttackCheckSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private GameSettings _settings;

        public AttackCheckSystem(Contexts contexts, GameSettings settings)
        {
            _settings = settings;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.AttackData, GameMatcher.Target, GameMatcher.MovementDirection));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.target.Value == null) continue;
                if (entity.attackData.LastTime + entity.attackData.Interval < Time.time)
                {
                    var distance = Vector3.Distance(entity.target.Value.view.Value.transform.position,
                        entity.view.Value.transform.position);
                    if (distance <= entity.attackData.Range)
                    {
                        entity.ReplaceAttackData(entity.attackData.Interval, entity.attackData.Range,
                            entity.attackData.Interval + Time.time);
                        entity.RemoveMovementDirection();
                        entity.AddAttackState(Time.time + _settings.monster.attackDelay);
                    }
                }
            }
        }
    }
}
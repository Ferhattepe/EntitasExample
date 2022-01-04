﻿using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MonsterNavmeshSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _monsters;

        public MonsterNavmeshSystem(Contexts contexts)
        {
            _monsters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Monster, GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var entity in _monsters.GetEntities())
            {
                var nearliestTarget = entity.target.Value;
                if (nearliestTarget != null)
                {
                    var direction =
                        (nearliestTarget.position - entity.view.Value.transform.position)
                        .normalized;
                    direction.y = 0;
                    entity.ReplaceMovementDirection(direction);
                }
                else
                {
                    entity.ReplaceMovementDirection(Vector3.zero);
                }
            }
        }
    }
}
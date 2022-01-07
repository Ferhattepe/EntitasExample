using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class MonsterDeathStateSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;

        public MonsterDeathStateSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Monster).NoneOf(GameMatcher.Alive));
        }

        public void Cleanup()
        {
            foreach (var entity in _group.GetEntities())
            {
                var monsterObject = entity.view.Value;
                entity.view.Value.transform.DOScale(0, 0.5f)
                    .OnComplete(() => { GameObject.Destroy(monsterObject); });
                entity.Destroy();
            }
        }
    }
}
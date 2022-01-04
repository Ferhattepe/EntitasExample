using Entitas;
using Sources.Settings;
using UnityEngine;

namespace Sources.Systems
{
    public class CalculatePlayerForwardSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private GameSettings _settings;

        public CalculatePlayerForwardSystem(Contexts contexts, GameSettings settings)
        {
            _settings = settings;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.MovementDirection,
                GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.target.Value == null)
                {
                    if (entity.movementDirection.Value != Vector3.zero)
                        entity.view.Value.transform.forward = Vector3.Lerp(entity.view.Value.transform.forward,
                            entity.movementDirection.Value, Time.deltaTime * _settings.player.rotationSpeed);
                }
                else
                {
                    var direction = entity.target.Value.view.Value.transform.position -
                                    entity.view.Value.transform.position;
                    direction.y = 0;
                    entity.view.Value.transform.forward = Vector3.Lerp(entity.view.Value.transform.forward,
                        direction.normalized, Time.deltaTime * _settings.player.rotationSpeed);
                }
            }
        }
    }
}
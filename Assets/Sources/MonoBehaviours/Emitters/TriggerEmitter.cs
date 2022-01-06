using Entitas.Unity;
using UnityEngine;

namespace Sources.MonoBehaviours.Emitters
{
    public class TriggerEmitter : MonoBehaviour
    {
        public string targetTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(targetTag))
            {
                var self = gameObject.GetEntityLink().entity as GameEntity;
                var target = other.gameObject.GetEntityLink().entity as GameEntity;
                Contexts.sharedInstance.game.CreateEntity()
                    .AddTrigger(self, target);
            }
        }
    }
}
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.MonoBehaviours.Emitters
{
    public class CollisionEmitter : MonoBehaviour
    {
        public string targetTag;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(targetTag))
            {
                var self = gameObject.GetEntityLink();
                var other = collision.collider.gameObject.GetEntityLink();
                
                Contexts.sharedInstance.input.CreateEntity()
                    .AddCollision(self, other);
            }
        }
    }
}
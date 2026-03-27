using Interfaces;
using Score;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollisionInteraction : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out IHittableByPlayer hittable)) return;
            hittable.OnPlayerCollide();
        }
    }
}

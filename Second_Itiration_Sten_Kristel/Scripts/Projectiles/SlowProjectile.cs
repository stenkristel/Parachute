using Interfaces;
using Parachute;
using UnityEngine;

namespace Projectiles
{
    public class SlowProjectile : Projectile
    {
        [SerializeField] private float slowAmount;
        [SerializeField] private float slowTime;
        protected void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out ISlowAble slowAble)) return;
            slowAble.Slow(slowAmount, slowTime);
            DestroySelf();
        }
    }
}

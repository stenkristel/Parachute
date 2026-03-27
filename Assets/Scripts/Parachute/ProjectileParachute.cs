using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parachute
{
    //Made by: Sten Kristel
    /// <summary>
    /// Variant of the parachute that will shoot out projectiles that speed up other parachutes
    /// </summary>
    public class ProjectileParachute : ParachuteBehaviour
    {
        [SerializeField] Projectile projectilePrefab;        //The speed-up projectile prefab
        [SerializeField] float fireDelay;                    //The delay between firing the speed projectile
        
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShootProjectileLoop());
        }
        
        private IEnumerator ShootProjectileLoop()
        {
            yield return new WaitForSeconds(fireDelay);
            var direction = Speed.x > 0 ? Vector2.right : Vector2.left; 
            SpawnProjectile(direction);
            StartCoroutine(ShootProjectileLoop());
        }
        
        private void SpawnProjectile(Vector2 direction)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.Initialize(direction);
        }
    }
}

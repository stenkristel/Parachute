using System.Collections;
using Projectiles;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parachute
{
    [RequireComponent(typeof(ParachuteMovement))]
    public class ProjectileParachute : MonoBehaviour
    {
        [SerializeField] Projectile projectilePrefab; 
        [SerializeField] float fireDelay;
        [SerializeField] ParachuteMovement movement;
        
        private void Start()
        {
            StartCoroutine(ShootProjectileLoop());
        }
        
        private IEnumerator ShootProjectileLoop()
        {
            yield return new WaitForSeconds(fireDelay);
            var direction = movement.Speed.x > 0 ? Vector2.right : Vector2.left; 
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

using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parachute
{
    //Made by: Sten Kristel
    /// <summary>
    /// Variant of the parachute that will shoot out projectiles that speed up other parachutes
    /// </summary>
    public class SpeedParachuteBehaviour : ParachuteBehaviour
    {
        [SerializeField] SpeedUpProjectile projectilePrefab;        //The speed-up projectile prefab
        [SerializeField] float fireDelay;                           //The delay between firing the speed projectile
        [SerializeField] float projectileSpeed;                     //The speed of the projectile
        [SerializeField] float parachuteSpeedMultiplier;            //The multiplier that will be given to the parachute when hit with the projectile

        /// <summary>
        /// Calls the base start of parachute and start the firing loop
        /// </summary>
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShootProjectileLoop());
        }

        /// <summary>
        /// Waits for fire delay, then determines the direction of the speed, based on the direction the parachute is moving,
        /// then spawns a projectile and start the loop again
        /// </summary>
        private IEnumerator ShootProjectileLoop()
        {
            yield return new WaitForSeconds(fireDelay);
            float prjSpeed = Speed.x > 0 ? -projectileSpeed : projectileSpeed; 
            SpawnProjectile(prjSpeed);
            StartCoroutine(ShootProjectileLoop());
        }

        /// <summary>
        /// Spawns a projectile and gives it, it's variables
        /// </summary>
        /// <param name="prjSpeed">The speed of the projectile, also determines direction</param>
        private void SpawnProjectile(float prjSpeed)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.Initialize(prjSpeed, parachuteSpeedMultiplier, this);
        }
    }
}

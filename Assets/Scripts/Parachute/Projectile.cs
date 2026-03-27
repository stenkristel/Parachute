using GameOver;
using UnityEngine;

namespace Parachute
{
    //Made by: Sten Kristel
    /// <summary>
    /// Projectile that will speed up any parachute it hits
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class SpeedUpProjectile : MonoBehaviour
    {
        [SerializeField] private string wallTag;            //Tag of the walls that make the projectile move the other way when hit
        
        private float _speed;                               //The speed at which the projectile moves, also determines direction
        private float _parachuteSpeedMultiplier;            //The multiplier the projectile will give when it hits a parachute
        private ParachuteMovement _spawnerParachute;       //The originator parachute that spawned this

        private void Start() => GameOverManager.Instance.OnGameOver += DestroySelf;     //Destroys self on game end to avoid issues

        private void OnDestroy() => GameOverManager.Instance.OnGameOver -= DestroySelf;

        private void FixedUpdate() => MoveProjectile();                                 //Moves the projectile every fixed frame

        /// <summary>
        /// On collision checks if it hit a wall or prachute, then executes beheviour depending on what was hit
        /// </summary>
        /// <param name="other">The other gameObject that was hit</param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (CheckForHitWall(other.gameObject)) return;
            CheckForHitParachute(other.gameObject);
        }

        /// <summary>
        /// Destroyes this gameobject
        /// </summary>
        private void DestroySelf()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Initializes variables on spawn
        /// </summary>
        /// <param name="speed">/The speed at which the projectile moves</param>
        /// <param name="speedMultiplier">The multiplier the projectile will give when it hits a parachute</param>
        /// <param name="spawnerParachute">The originator parachute that spawned this</param>
        public void Initialize(float speed, float speedMultiplier, ParachuteMovement spawnerParachute)
        {
            _speed = speed;
            _parachuteSpeedMultiplier = speedMultiplier;
            _spawnerParachute = spawnerParachute;
        }


        /// <summary>
        /// Moves the projectile at a set speed. Uses Time.deltaTime to make sure it isn't dependent on fps
        /// </summary>
        private void MoveProjectile()
        {
            transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;
        }

        /// <summary>
        /// Checks if hitGamobject has the wall tag, if it does, it reverses moving direction and returns true
        /// If hitGameobject does not have the wall tag, returns false
        /// </summary>
        /// <param name="hitGameObject">The hit GameObject</param>
        /// <returns></returns>
        private bool CheckForHitWall(GameObject hitGameObject)
        {
            if (hitGameObject.CompareTag(wallTag))
            {
                _speed = -_speed;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the hitGameObject is a parachute other than the one that spawned this.
        /// if it is: multiplies the speed of the parachute and destroys self
        /// </summary>
        /// <param name="hitGameObject">The hit GameObject</param>  
        private void CheckForHitParachute(GameObject hitGameObject)
        {
            var parachute = hitGameObject.GetComponent<ParachuteMovement>();
            if (parachute == null || parachute == _spawnerParachute) return;
            parachute.Speed *= _parachuteSpeedMultiplier;
            Destroy(gameObject);
        }
    }
}

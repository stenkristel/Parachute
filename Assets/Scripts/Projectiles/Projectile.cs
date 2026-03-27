using GameOver;
using UnityEngine;

namespace Parachute
{
    //Made by: Sten Kristel
    /// <summary>
    /// Projectile that will speed up any parachute it hits
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private string wallTag;            //Tag of the walls that make the projectile move the other way when hit
        [SerializeField] Vector3 speed;                       //The speed of the projectile
        
        private void Start()
        {
            GameOverManager.Instance.OnGameOver += DestroySelf;
        }

        private void OnDestroy()
        {
            GameOverManager.Instance.OnGameOver -= DestroySelf;
        }

        private void FixedUpdate()
        {
            Move();
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (CheckForHitWall(other.gameObject)) return;
        }

        protected void DestroySelf()
        {
            Destroy(gameObject);
        }
        
        public void Initialize(Vector2 moveDirection)
        {
            speed.x *= moveDirection.x;
        }
        
        private void Move()
        {
            transform.position += speed * Time.deltaTime;
        }
        
        private bool CheckForHitWall(GameObject hitGameObject)
        {
            if (!hitGameObject.CompareTag(wallTag)) return false;
            speed.x = -speed.x;
            return true;
        }
    }
}

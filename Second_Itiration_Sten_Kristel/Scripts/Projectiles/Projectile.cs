using GameOver;
using Interfaces;
using UnityEngine;

namespace Projectiles
{
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour, IWallCollideAble, IHittableByBottomBorder
    {
        [SerializeField] Vector3 speed;         
        
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

        protected void DestroySelf()
        {
            Destroy(gameObject);
        }

        public void Initialize(Vector2 moveDirection)
        {
            speed.x *= moveDirection.x;
        }

        public void OnWallCollide()
        {
            speed.x = -speed.x;
        }

        public void OnBorderCollide()
        {
            DestroySelf();
        }

        private void Move()
        {
            transform.position += speed * Time.deltaTime;
        }
    }
}

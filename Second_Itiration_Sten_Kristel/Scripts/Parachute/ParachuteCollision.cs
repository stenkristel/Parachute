using GameOver;
using Interfaces;
using Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Parachute
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(ParachuteMovement))]
    public class ParachuteCollision : MonoBehaviour, IHittableByBottomBorder, IHittableByPlayer, IWallCollideAble
    {
        [SerializeField] private ParachuteMovement movement;
        [SerializeField] private int playerHitScoreIncrease;
        public void OnBorderCollide()
        {
            GameOverManager.Instance.ParachuteMiss();
            Destroy(gameObject);
        }

        public void OnPlayerCollide()
        {
            ScoreManager.Instance.AddScore(playerHitScoreIncrease);
            Destroy(gameObject);
        }
        
        public void OnWallCollide()
        {
            if (movement == null)
            {
                Debug.LogError("No movement assigned");
                return;
            }
            movement.Speed = new Vector3(-movement.Speed.x, movement.Speed.y, 0f);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}

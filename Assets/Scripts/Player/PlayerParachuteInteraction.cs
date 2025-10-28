using Score;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Made by Sten Kristel
    /// When this collides with an object with the parachuteTag,
    /// it will destroy the object and add a score to ScoreManager
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class PlayerParachuteInteraction : MonoBehaviour
    {
        [SerializeField] private int parachuteScoreChange;  //The score that will be added on a collision with a parachute
        [SerializeField] private string parachuteTag;       //The tag that parachutes have

        /// <summary>
        /// Checks if this collided with something that has the parachuteTag
        /// If it has, add score to ScoreManager
        /// </summary>
        /// <param name="other">The other collider with which this collided</param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(parachuteTag)) return;
            Destroy(other.gameObject); 
            ScoreManager.Instance.AddScore(parachuteScoreChange);
        }
    }
}

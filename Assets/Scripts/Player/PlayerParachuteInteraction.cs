using Score;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerParachuteInteraction : MonoBehaviour
    {
        [SerializeField] private int parachuteScoreChange;
        [SerializeField] private string parachuteTag;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(parachuteTag)) return;
            Destroy(other.gameObject); 
            ScoreManager.Instance.AddScore(parachuteScoreChange);
        }
    }
}

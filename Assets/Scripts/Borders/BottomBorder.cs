using GameOver;
using Interfaces;
using UnityEngine;

namespace Borders
{
    //Made by: Sten Kristel
    
    [RequireComponent(typeof(Collider2D))]
    public class BottomBorder : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out IHittableByBottomBorder hittable))
            {
                return;
            }
            
            hittable.OnBorderCollide();
        }
    }
}

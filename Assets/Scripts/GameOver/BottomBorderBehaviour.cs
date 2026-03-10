using System;
using UnityEngine;

namespace GameOver
{
    //Made by: Sten Kristel
    /// <summary>
    /// Class that when hit by an object will destroy the object and tell the DefeatManager that the bottom border has been hit
    /// </summary>
    
    [RequireComponent(typeof(Collider2D))]
    public class BottomBorderBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Destroy object on collision and tell GameOverManager that a parachute has been missed
        /// </summary>
        /// <param name="other">The other object that has been hit</param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(other.gameObject);
            GameOverManager.Instance.ParachuteMiss();
        }
    }
}

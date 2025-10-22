using UnityEngine;

namespace Defeat
{
    //Made by: Sten Kristel
    /// <summary>
    /// Class that when hit by an object will destroy the object and tell the DefeatManager that the bottom border has been hit
    /// </summary>
    
    [RequireComponent(typeof(Collider))]
    public class BottomBorderBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Destroy(other.gameObject);
            DefeatManager.Instance.OnHitBottomBorder();
        }
    }
}

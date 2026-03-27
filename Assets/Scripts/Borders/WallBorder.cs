using System;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Borders
{
    [RequireComponent(typeof(Collider2D))]
    public class WallBorder : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out IWallCollideAble bounceAble))
            {
                return;
            }
            
            bounceAble.OnWallCollide();
        }
    }
}

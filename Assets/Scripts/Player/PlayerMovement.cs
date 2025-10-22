using System;
using UnityEngine;

namespace Player
{
    //Made by: Sten Kristel
    /// <summary>
    /// Moves the player from left and right
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float moveAcceleration;
        [SerializeField] private float moveDrag;
        [SerializeField] private KeyCode moveRightKey;
        [SerializeField] private KeyCode moveLeftKey;

        //private float _movementLastFrame;
        private void FixedUpdate()
        {
            DetectInput();
        }

        private void DetectInput()
        {
            if (!Input.GetKey(moveLeftKey) && !Input.GetKey(moveRightKey)) return ;
            bool isMovingRight = Input.GetKey(moveRightKey);
            MovePlayer(isMovingRight);
        }
        private void MovePlayer(bool isMovingRight)
        {
            float speed = isMovingRight ? moveSpeed : -moveSpeed;
            //float acceleration = isMovingRight ? moveAcceleration : -moveAcceleration;
            //speed += acceleration;
            speed *= Time.deltaTime;
            //speed += _movementLastFrame;
            
            gameObject.transform.position += new Vector3(speed, 0f, 0f);
            
            //_movementLastFrame = speed;
        }
    }
}

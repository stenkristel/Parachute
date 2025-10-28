using System;
using UnityEngine;

namespace Player
{
    //Made by: Sten Kristel
    /// <summary>
    /// Moves the player to the left and right, based on the input and speed set in the editor
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;           //The speed which the player will move
        [SerializeField] private KeyCode moveRightKey;      //The Key to press to make the player move to the right
        [SerializeField] private KeyCode moveLeftKey;       //The Key to press to make the player move to the left 
        
        private void FixedUpdate() => DetectInput();        //Checks for input every fixed frame

        
        /// <summary>
        /// Checks if the player has input the moveLeftKey of moveRightKey, if not returns
        /// Calls movePlayer and tells it if the player was pressing the moveRightKey
        /// </summary>
        private void DetectInput()
        {
            if (!Input.GetKey(moveLeftKey) && !Input.GetKey(moveRightKey)) return;
            bool isMovingRight = Input.GetKey(moveRightKey);
            MovePlayer(isMovingRight);
        }
        
        /// <summary>
        /// If the player wasn't moving to the right, it reverses speed so it will go to the left
        /// Then moves the player based on speed and how many frames the player has
        /// </summary>
        /// <param name="isMovingRight">Bool that tells if the player is moving to the right, if not? player is moving left</param>
        private void MovePlayer(bool isMovingRight)
        {
            float speed = isMovingRight ? moveSpeed : -moveSpeed;
            speed *= Time.deltaTime;
            gameObject.transform.position += new Vector3(speed, 0f, 0f);
        }
    }
}

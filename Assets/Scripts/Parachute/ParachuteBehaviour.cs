using Defeat;
using Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parachute
{
    //Made by: Sten Kristel
    ///<summary>
    ///Moves the parachute to the bottom and to the left at random speed determined by randomXSpeedParameters and randomYSpeedParameters
    ///When it hits a wall, it will automatically move the other way and flip the spriteRenderer image
    /// </summary>
    
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ParachuteBehaviour : MonoBehaviour
    {
        [SerializeField] private MinAndMaxFloats randomXSpeedParameters;  //Min X speed and max X speed, to be adjusted in the editor.
        [SerializeField] private MinAndMaxFloats randomYSpeedParameters;  //Min Y speed and max Y speed, to be adjusted in the editor.
        [SerializeField] private string wallTag;                                //The tag the walls have that the parachute will bounce against, adjusted in the editor.
        [SerializeField] private SpriteRenderer spriteRenderer;                 //The sprite renderer used for flipping the image.

        private float xSpeed;                                                   //The speed at which the parachute moves along the X axis, becomes assigned at start
        private float ySpeed;                                                   //The speed at which the parachute moves along the Y axis, becomes assigned at start

        /// <summary>
        /// Assigns events and calculates the X and Y speeds on first frame.
        /// </summary>
        private void Start()
        {
            AssignsEvents();
            GenerateSpeed(); 
        }

        private void OnDestroy() => UnAssignEvents();           //Unassigns events on destroy. (prevents issues on scene changes)

        private void FixedUpdate() => MoveParachute();          //Moves the parachute to a new position every fixed frame.

        /// <summary>
        /// Triggers when the parachute enters a collider, will return if the collider doesn't belong to a wall.
        /// If it collides with a wall, will reverse the X speed so it moves the other way, and flips the asset.
        /// </summary>
        /// <param name="other">"The other collider with which the parachute collided"</param>
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag(wallTag)) {return;}
            xSpeed = -xSpeed;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        private void AssignsEvents() => DefeatManager.Instance.OnDefeat += DestroySelf;     //Assigns destroySelf on OnDefeat
        
        private void UnAssignEvents() => DefeatManager.Instance.OnDefeat -= DestroySelf;    //Unassigns DestroySelf on OnDefeat

        private void DestroySelf() => Destroy(gameObject);                                  //Destroys the gameobject

        /// <summary>
        /// Sets random values to xSpeed and ySpeed using the minValue and maxValue of randomXSpeedParameters and randomYSpeedParameters
        /// </summary>
        private void GenerateSpeed()
        {
            xSpeed = Random.Range(randomXSpeedParameters.minValue, randomXSpeedParameters.maxValue);
            ySpeed = Random.Range(randomYSpeedParameters.minValue, randomYSpeedParameters.maxValue);
        }
        
        /// <summary>
        /// Moves the parachute to a new position based on xSpeed and ySpeed. Uses Time.deltaTime to make sure it isn't dependent on fps
        /// </summary>
        private void MoveParachute()
        {
            transform.position -= new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
        }
        
    }
}

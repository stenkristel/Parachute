using GameOver;
using Interfaces;
using Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parachute
{
    public class ParachuteMovement : MonoBehaviour
    {
        [SerializeField] private MinAndMaxFloats randomXSpeedParameters;        //Min X speed and max X speed, to be adjusted in the editor.
        [SerializeField] private MinAndMaxFloats randomYSpeedParameters;        //Min Y speed and max Y speed, to be adjusted in the editor.

        protected float xSpeed;                                                   //The speed at which the parachute moves along the X axis, becomes assigned at start
        protected float ySpeed;                                                   //The speed at which the parachute moves along the Y axis, becomes assigned at start
        
        private Vector3 _speed;

        public Vector3 Speed
        {
            get => _speed; set =>  _speed = value;
        }
        
        protected virtual void Start()
        {
            AssignsEvents();
            SetRandomSpeed(); 
        }

        private void OnDestroy()
        {
            UnAssignEvents();
        }       

        private void FixedUpdate()
        {
            Move();
        }      

        private void AssignsEvents()
        {
            GameOverManager.Instance.OnGameOver += DestroySelf;
        }

        private void UnAssignEvents()
        {
            GameOverManager.Instance.OnGameOver -= DestroySelf;
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }                             

        private void SetSpeed(Vector2 speed)
        {
            Speed =  speed;
        }
        
        private void SetRandomSpeed()
        {
            xSpeed = Random.Range(randomXSpeedParameters.minValue, randomXSpeedParameters.maxValue);
            ySpeed = Random.Range(randomYSpeedParameters.minValue, randomYSpeedParameters.maxValue);
            SetSpeed(new Vector3(xSpeed, ySpeed, 0f));
        }
        
        private void Move()
        {
            transform.position -= _speed * Time.deltaTime;
        }

    }
}

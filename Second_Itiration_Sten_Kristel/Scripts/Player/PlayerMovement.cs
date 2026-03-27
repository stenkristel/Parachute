using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, ISlowAble
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float diveDepth;
        [SerializeField] private float diveDuration;

        private float _speed;
        private bool _isDiving;

        private void Start()
        {
            _speed = moveSpeed;
        }

        public void MovePlayer(float direction)
        {
            var speed = _speed * direction * Time.deltaTime;
            gameObject.transform.position += new Vector3(speed, 0f, 0f);
        }

        public void Dive()
        {
            if (_isDiving)
            {
                return;
            }
            
            StartCoroutine(DiveMovement(diveDepth, diveDuration));
        }

        public void Slow(float slowAmount, float slowTime)
        {
            StopCoroutine(SlowTimer(slowAmount, slowTime));
            StartCoroutine(SlowTimer(slowAmount, slowTime));
        }

        private IEnumerator SlowTimer(float slowAmount, float slowTime)
        {
            _speed -= slowAmount;
            if (_speed < 0) _speed = 0;
            yield return new WaitForSeconds(slowTime);
            _speed = moveSpeed;
        }

        private IEnumerator DiveMovement(float depth, float duration)
        {
            _isDiving = true;
            
            float elapsedTime = 0f;
            float halfDuration = duration / 2f;
            float offsetY = 0f;

            while (elapsedTime < halfDuration)
            {
                float time = elapsedTime / halfDuration;
                float targetOffset = Mathf.Lerp(0f, -depth, time);

                float delta = targetOffset - offsetY;
                transform.position += new Vector3(0f, delta, 0f);

                offsetY = targetOffset;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0f;

            while (elapsedTime < halfDuration)
            {
                float time = elapsedTime / halfDuration;
                float targetOffset = Mathf.Lerp(-depth, 0f, time);

                float delta = targetOffset - offsetY;
                transform.position += new Vector3(0f, delta, 0f);

                offsetY = targetOffset;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _isDiving = false;
        }
    }
}

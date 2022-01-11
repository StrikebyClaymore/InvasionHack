using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        private Vector3 _offset;
        //[Range(0.2f, 0.8f)] [SerializeField] private float smoothSpeed = 0.1f;
        
        private void Start()
        {
            _offset = transform.position;
        }

        private void LateUpdate()
        {
            transform.position = target.position + _offset;
        }

        private void FixedUpdate()
        {
            /*var position = target.position + _offset;
            var smoothVector = Vector3.Lerp(transform.position, position, smoothSpeed);
            transform.position = smoothVector;*/
            
            //transform.LookAt(target);
            
            //transform.position = target.position + _offset;
        }
    }
}
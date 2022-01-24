using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Mobs.Player;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Camera cam;
        [SerializeField] private Transform outer;
        [SerializeField] private Transform inner;
        private float _outerRadius;

        private bool _touchPressed;
        private Vector3 _touchStart;

        private void Awake()
        {
            _outerRadius = outer.GetComponent<RectTransform>().rect.width / 2;
           
        }

        private void Update()
        {
            TouchPress();
            TouchMove();
            return;
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var touchPos = cam.ScreenToWorldPoint(touch.position);
                touchPos.z = 0f;

                var direction = inner.position - outer.position;
                if (direction.sqrMagnitude < _outerRadius * _outerRadius)
                {
                    
                }
                Debug.Log("Press");
                playerMovement.transform.position = touchPos;
                //playerMovement.Direction = direction.normalized;
            }
        }

        private void TouchPress()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Vector3.Distance(Input.mousePosition, outer.position) > _outerRadius)
                    return;
                _touchPressed = true;
                _touchStart = Input.mousePosition;
                inner.position = _touchStart;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _touchPressed = false;
                inner.position = outer.position;
                playerMovement.Direction = Vector3.zero;
            }
        }

        private void TouchMove()
        {
            if(!_touchPressed)
                return;
            
            var touchPos = Input.mousePosition;
            var direction = (touchPos - _touchStart).normalized;
            var dist = Vector3.Distance(touchPos, outer.position);

            if (dist < _outerRadius)
                inner.position = touchPos;
            else
                inner.position = outer.position + direction * Mathf.Min(_outerRadius, dist);

            var start = new Vector3(_touchStart.x, 0f, _touchStart.y);
            var end = new Vector3(touchPos.x, 0f, touchPos.y);
            direction = (end - start).normalized;
            playerMovement.Direction = direction;
            //Debug.Log("");
        }
    }
}

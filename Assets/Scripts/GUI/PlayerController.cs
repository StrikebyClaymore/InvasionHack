using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Mobs.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.GUI
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerControls root;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Camera cam;
        [SerializeField] private Transform outer;
        [SerializeField] private Transform inner;
        private float _outerRadius;
        private bool _touchPressed;

        private void Awake()
        {
            _outerRadius = outer.GetComponent<RectTransform>().rect.width / 2;
        }

        public void Move(Vector3 touchPos)
        {
            var center = outer.position;
            var direction = (touchPos - center).normalized;
            var dist = Vector3.Distance(touchPos, center);

            if (dist <= _outerRadius)
                inner.position = touchPos;
            else
                inner.position = outer.position + direction * Mathf.Min(_outerRadius, dist);

            var start = new Vector3(center.x, 0f, center.y);
            var end = new Vector3(touchPos.x, 0f, touchPos.y);
            direction = (end - start).normalized;
            playerMovement.Direction = direction;
        }

        public void StopMove()
        {
            inner.position = outer.position;
            playerMovement.Direction = Vector3.zero;
        }
    }
}

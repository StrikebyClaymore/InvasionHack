using System;
using System.Collections.Generic;
using Assets.Scripts.Mobs.Player;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class PlayerControls : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAttack playerAttack;

        [SerializeField] private Camera cam;
        
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Transform nitroButton;
        [SerializeField] private Transform attackButton;

        [NonSerialized] public bool NitroPressed;
        [NonSerialized] public bool AttackPressed;

        //public enum Actions { None, Joystick, Button }
        //private Dictionary<Actions, int> touches = new Dictionary<Actions, int> { };
        //private const int TouchesMax = 2;

        private class TouchData
        {
            public int index;
            public Vector3 position;
            public bool pressed;
            public Transform transform;
            public Transform oldTransform;

            public TouchData(int idx) => index = idx;
        }

        private readonly TouchData[] touches = { new TouchData(0), new TouchData(1) };
        
        private class Control
        {
            public Transform transform;
            public bool pressed;

            public Control(Transform t) => transform = t;
        }

        private Control[] controls;
        
        private bool _locked = false;

        private void Awake()
        {
            controls = new []{ new Control(playerController.transform), new Control(nitroButton), new Control(attackButton) };
        }

        private void Update()
        {
            foreach (var ev in Input.touches)
            {
                var touch = touches[ev.fingerId];
                if (ev.phase == TouchPhase.Began)
                    TouchDown(touch, ev);
                else if (ev.phase == TouchPhase.Ended)
                    TouchUp(touch);
                else if(ev.phase == TouchPhase.Moved)
                    TouchMove(touch, ev);
            }
        }

        private void FixedUpdate()
        {
            foreach (var touch in touches)
            {
                if(!touch.pressed)
                    continue;
                if (touch.transform == playerController.transform)
                {
                    playerController.Move(touch.position);
                }
            }
        }

        private void TouchMove(TouchData touch, Touch ev)
        {
            touch.position = ev.position;
        }
        
        private void TouchDown(TouchData touch, Touch ev)
        {
            touch.position = ev.position;
            touch.pressed = true;
            foreach (var c in controls)
            {
                if (PointInCircle(c.transform, touch.position))
                {
                    touch.transform = c.transform;
                }
            }
        }
        
        private void TouchUp(TouchData touch)
        {
            if (touch.transform == playerController.transform)
                playerController.StopMove();
            touch.transform = null;
            touch.pressed = false;
        }
        
        private bool PointInCircle(Transform t, Vector3 p)
        {
            var tp = t.position;
            var r = t.GetComponent<RectTransform>().rect.width / 2;
            return Vector3.Distance(p, tp) <= r;
        }
        
        public void OnNitroDown()
        {
            
        }

        public void OnNitroUp()
        {
            
        }
        
        public void OnAttackDown()
        {
            playerAttack.IsFireOn = true;
        }

        public void OnAttackUp()
        {
            playerAttack.IsFireOn = false;
        }

        public void LockInput() => _locked = !_locked;
    }
}

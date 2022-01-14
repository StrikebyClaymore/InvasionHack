using UnityEngine;

namespace Assets.Scripts.Mobs.Player
{
    public class PlayerControl : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAttack _playerAttack;

        private bool _lock = false;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAttack = GetComponent<PlayerAttack>();
        }

        private void Update()
        {
            if(_lock)
                return;
            InputProcess();
        }

        public void Lock()
        {
            _lock = !_lock;
            if (_lock)
            {
                _playerMovement.Direction = Vector3.zero;
                _playerAttack.IsFireOn = false;
                Invoke(nameof(Lock), 1.5f);
            }
        }
        
        private void InputProcess()
        {
            MouseInput();
            KeyboardInput();
        }

        private void MouseInput()
        {
            if (Input.GetMouseButton(0))
            {
                _playerAttack.IsFireOn = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _playerAttack.IsFireOn = false;
            }
        }
        
        private void KeyboardInput()
        {
            var direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction.z = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction.z = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            _playerMovement.Direction = direction.normalized;
        }
    }
}

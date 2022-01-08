using UnityEngine;

namespace Assets.Scripts.Mobs.Player
{
    public class PlayerControl : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAttack _playerAttack;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAttack = GetComponent<PlayerAttack>();
        }

        private void Update()
        {
            InputProcess();
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

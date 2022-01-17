using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mobs.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController _character;
        //private BoxCollider _collider;
        private Transform _camera;
        //[SerializeField]
        //private Vector3 cameraOffset;
        [SerializeField]
        private float moveSpeed; 
        private Vector3 _direction = Vector3.zero;
        public Vector3 Direction { get => _direction;  set => _direction = value; }
        private Vector3 _velocity;
        [SerializeField]
        private float rotationSpeed = 360f;
        //[SerializeField] private LayerMask movementCollideLayer;

        private void Awake()
        {
            _character = GetComponent<CharacterController>();
            //_collider = GetComponent<BoxCollider>();
            _camera = transform.parent.Find("Player Camera");
        }

        private void Start()
        {
            //cameraOffset = _camera.position;
        }

        private void Update()
        {
            PreMove();
        }

        private void FixedUpdate()
        {
            Rotate();
            Move();
            Gravity();
        }

        private void LateUpdate()
        {
            //MoveCamera();
        }

        private void PreMove()
        {
            if (Direction.z == 0)
                return;
            var direction = transform.forward * Direction.z;
            _velocity = Vector3.ClampMagnitude( direction * moveSpeed, moveSpeed);
        }

        private void Move()
        {
            if (_velocity == Vector3.zero)
                return;
            _character.Move(_velocity * Time.fixedDeltaTime);
            //MoveCamera();
            _velocity = Vector3.zero;
        }

        private void Gravity()
        {
            if (_character.isGrounded)
                return;
            var gravity = Vector3.down * (9.8f * Time.fixedDeltaTime);
            _character.Move(gravity);
        }

        private void Rotate()
        {
            if (Direction.x == 0)
                return;
            
            transform.Rotate(new Vector3(0f, Direction.x * rotationSpeed * Time.fixedDeltaTime, 0f));
        }
        
        
        /*private void MoveCamera()
        {
            //_camera.transform.Translate(_velocity);
            //_camera.position = transform.position + cameraOffset;
        }*/
    }
}
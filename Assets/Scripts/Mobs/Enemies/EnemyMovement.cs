using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Mobs.Enemies
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        protected NavMeshAgent Agent;
        protected EnemyAttack Attack;
        public enum States { None, Idle, Wait, MoveToPoint, Follow }
        private States _state;
        private bool _moveAllowed = true;
        private Vector3 velocity;
        private Vector3 direction;
        [SerializeField]
        private float moveSpeed;
        protected Mob Target;
        protected Vector3 TargetPoint;
        [SerializeField]
        private float stopDistance = 1.2f;
        private float _pointStopDistance = 0.15f;

        private NavMeshPath path;
        private int pointIndex = 1;
        private float _findPathProgress;
        private float _pathHeight = 0.4f;
        
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Attack = GetComponent<EnemyAttack>();
        }

        private void Start()
        {
            path = new NavMeshPath();
            SetTarget(new Vector3(7.5f, 0f, transform.position.z));
            //SetTarget(new Vector3(Random.Range(-14f, 14f), 0f, Random.Range(-14f, 14f)));
        }

        private void Update()
        {
            if (_state == States.MoveToPoint)
                MoveToPoint();
            else if(_state == States.Follow)
                Follow();
            if (_state != States.Wait)
                UpdatePath();
        }

        private void FixedUpdate()
        {
            ChangePosition();
        }

        private void ChangePosition()
        {
            if(velocity == Vector3.zero)
                return;
            velocity *= Time.fixedDeltaTime;
            transform.LookAt(transform.position + direction);
            //transform.Translate(velocity, Space.World);
            Agent.Move(velocity);
            direction = Vector3.zero;
            velocity = Vector3.zero;
        }
        
        protected virtual void MoveToPoint()
        {
            var pos = transform.position;
            var point = path.corners.Length - pointIndex <= 1 ? TargetPoint : path.corners[pointIndex] + new Vector3(0f, _pathHeight, 0f);

            direction = (point - pos).normalized;
            direction.y = 0;
            velocity = direction * moveSpeed;
            
            //Debug.DrawLine(pos, point, Color.red);
            //print(Vector3.Distance(pos, point) +"  "+ point);

            CheckDistanceToTarget(point, Target && pointIndex == path.corners.Length - 1 ? stopDistance : _pointStopDistance);
        }

        private void CheckDistanceToTarget(Vector3 point, float stopDistance)
        {
            //Debug.Log(Vector3.Distance(transform.position, point));
            if (Vector3.Distance(transform.position, point) < stopDistance)
            {
                pointIndex = Mathf.Min(pointIndex + 1, path.corners.Length);
                
                if (pointIndex == path.corners.Length)
                {
                    ChangeState(States.Idle);
                }
            }
        }
        
        protected virtual void Follow()
        {
            if (!FindPath())
            {
                ChangeState(States.Idle);
                return;
            }
            MoveToPoint();
        }

        protected virtual void SetIdle() { }
        
        protected virtual void SetWait() { }

        protected virtual void SetTarget(Vector3 target)
        {
            Target = null;
            TargetPoint = target;
            SetMove();
        }
        
        public virtual void SetTarget(Mob target)
        {
            Target = target;
            if (Target is null)
            {
                ChangeState(States.Idle);
                return;
            }
            TargetPoint = Target.transform.position;
            SetMove();
        }
        
        protected virtual void SetMove()
        {
            if (!FindPath())
                return;
            ChangeState(Target ? States.Follow : States.MoveToPoint);
        }
        
        protected bool FindPath()
        {
            if (Vector3.Distance(transform.position, TargetPoint) <= stopDistance)
                return false;
            pointIndex = 1;
            //var point = new Vector3(TargetPoint.x, 0.5f, TargetPoint.z);
            NavMesh.CalculatePath(transform.position, TargetPoint, NavMesh.AllAreas, path);

            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                //Debug.DrawLine(path.corners[i], path.corners[i+1], Color.red, 10.0f);
            }
            
            return path.corners.Length > 1;
        }
        
        private void UpdatePath()
        {
            if (!Target)
                return;
            _findPathProgress += Time.deltaTime;
            if (_findPathProgress >= 0.2f)
            {
                _findPathProgress = 0;
                TargetPoint = Target.transform.position;
                if (!FindPath())
                    return;
                ChangeState(States.Follow);
            }
        }
        
        public void AllowMove(bool allow)
        {
            _moveAllowed = allow;
            if (allow)
                ChangeState(States.MoveToPoint);
            else
                ChangeState(States.Idle);
        }

        protected virtual void ChangeState(States newState)
        {
            switch (newState)
            {
                case States.Idle:
                    SetIdle();
                    break;
                case States.Wait:
                    SetWait();
                    break;
                case States.MoveToPoint:
                    break;
                case States.Follow:
                    break;
                default:
                    break;
            }
            _state = newState;
        }
    }
}

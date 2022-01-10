using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Mobs.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        protected NavMeshAgent Agent;
        protected EnemyAttack Attack;
        public enum States { None, Idle, Wait, Move, Follow }
        private States _state;
        private bool _moveAllowed = true;
        [SerializeField] private float moveSpeed;
        protected GameObject Target;
        protected Vector3 TargetPoint;
        [SerializeField] private float stopDistance = 2.0f;

        private NavMeshPath path;
        private int pointIndex = 1;
        
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Attack = GetComponent<EnemyAttack>();   
            //SetTarget(new Vector3(Random.Range(-14f, 14f), 0f, Random.Range(-14f, 14f)));
            SetTarget(new Vector3(12f, 0f, transform.position.z));
        }

        private void Update()
        {
            if (_state == States.Move)
                Move();
            else if(_state == States.Follow)
                Follow();
        }

        protected virtual void Move()
        {
            if (Vector3.Distance(transform.position, TargetPoint) <= stopDistance)
            {
                //ChangeState(States.Idle);
                SetTarget(new Vector3(TargetPoint.x * -1, 0f, TargetPoint.z));
            }
        }

        protected virtual void Follow()
        {
            Agent.destination = Target.transform.position;
        }
        
        protected virtual void SetIdle()
        {
            Agent.enabled = false;
        }
        
        protected virtual void SetWait() { }

        protected virtual void SetTarget(Vector3 target)
        {
            TargetPoint = target;
            Agent.stoppingDistance = 0f;
            SetMove();
        }
        
        public virtual void SetTarget(GameObject target)
        {
            Target = target;
            if (Target is null)
            {
                ChangeState(States.Idle);
                return;
            }
            Agent.stoppingDistance = stopDistance;
            SetMove();
        }
        
        protected virtual void SetMove()
        {
            Agent.enabled = true;
            Agent.destination = Target != null ? Target.transform.position : TargetPoint;
            if (Agent.destination == default)
            {
                Agent.enabled = false;
                return;
            }
            Agent.enabled = true;
            ChangeState(Target ? States.Follow : States.Move);
        }
        
                
        public void AllowMove()
        {
            _moveAllowed = true;
            ChangeState(States.Move);
        }

        protected void ChangeState(States newState)
        {
            switch (newState)
            {
                case States.Idle:
                    SetIdle();
                    break;
                case States.Wait:
                    SetWait();
                    break;
                case States.Move:
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

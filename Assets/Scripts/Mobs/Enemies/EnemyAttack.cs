using System;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        protected EnemyMovement Movement;
        protected Mob Target;
        protected enum States { None, Attack, Cooldown }
        private States _state;
        private bool _attackAllowed = true;
        protected Timer CoolldownTimer;
        [SerializeField] private float attackCooldownTime = 1.0f;
        protected bool AttackIsCooldown = false;
        [SerializeField] protected float attackDistance = 1.5f;
        [SerializeField] protected int attackDamage = 1;
        
        
        private void Awake()
        {
            Movement = GetComponent<EnemyMovement>();
            
            CoolldownTimer = new Timer(attackCooldownTime * 1000f);
            CoolldownTimer.Elapsed += OnAttackCooldownTimeout;
        }

        /*protected virtual void Update()
        {
            if (Target is null)
                return;
            if (Vector3.Distance(transform.position, Target.transform.position) <= attackDistance)
            {
                Attack();
            }
        }*/

        protected abstract void Attack();

        public void AllowAttack(bool allow)
        {
            _attackAllowed = allow;
            if (!allow) 
                ChangeState(States.None);
        }

        public virtual void SetTarget(Mob target)
        {
            Target = target;
        }
        
        protected void ChangeState(States newState)
        {
            switch (newState)
            {
                case States.Attack:
                    break;
                case States.Cooldown:
                    break;
                default:
                    break;
            }
            _state = newState;
        }

        protected virtual void OnAttackCooldownTimeout(object source, ElapsedEventArgs e)
        {
            AttackIsCooldown = false;
            CoolldownTimer.Enabled = false;
        }
    }
}
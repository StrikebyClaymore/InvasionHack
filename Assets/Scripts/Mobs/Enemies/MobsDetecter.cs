using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.Mobs.Enemies
{
    public class MobsDetecter : MonoBehaviour
    {
        private EnemyMovement _movement;
        private EnemyAttack _attack;

        public void Initialize(EnemyMovement m, EnemyAttack a)
        {
            _movement = m;
            _attack = a;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _movement.SetTarget(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _movement.SetTarget(null);
            }
        }
    }
}

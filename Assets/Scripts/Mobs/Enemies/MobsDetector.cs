using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts.Mobs.Enemies
{
    public class MobsDetector : MonoBehaviour
    {
        private EnemyMovement _movement;
        private EnemyAttack _attack;

        private void Awake()
        {
            _movement = GetComponentInParent<EnemyMovement>();
            _attack = GetComponentInParent<EnemyAttack>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _movement.SetTarget(other.gameObject.GetComponent<Mob>());
                _attack.SetTarget(other.gameObject.GetComponent<Mob>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _movement.SetTarget(null);
                _attack.SetTarget(null);
            }
        }
    }
}

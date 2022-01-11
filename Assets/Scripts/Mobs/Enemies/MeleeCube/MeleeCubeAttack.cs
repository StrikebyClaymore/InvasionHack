using System;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.MeleeCube
{
    public class MeleeCubeAttack : EnemyAttack
    {
        private void Update()
        {
            if (Target is null)
                return;
            if (Vector3.Distance(transform.position, Target.transform.position) <= attackDistance)
            {
                Attack();
            }
        }

        protected override void Attack()
        {
            if (AttackIsCooldown)
                return;
            Target.GetHit(attackDamage);
            AttackIsCooldown = true;
            CoolldownTimer.Enabled = true;
        }
    }
}

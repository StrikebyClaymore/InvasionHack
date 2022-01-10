using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.MeleeCube
{
    public class MeleeCubeAttack : EnemyAttack
    {
        protected override void Attack()
        {
            if (AttackIsCooldown)
                return;
            AttackIsCooldown = true;
            CoolldownTimer.Enabled = true;
        }
    }
}

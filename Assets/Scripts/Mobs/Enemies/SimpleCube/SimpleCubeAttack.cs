using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.SimpleCube
{
    public class SimpleCubeAttack : EnemyAttack
    {
        public void Collapse(Enemy body)
        {
            if (gameObject.GetInstanceID() < body.gameObject.GetInstanceID())
                Attack();
        }

        protected override void Attack()
        {
            Debug.Log("EXPLODE");
        }
    }
}

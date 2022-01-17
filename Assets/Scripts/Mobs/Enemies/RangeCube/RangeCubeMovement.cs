using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.RangeCube
{
    public class RangeCubeMovement : EnemyMovement
    {
        protected override void Start()
        {
            base.Start();
            SetTarget(GameManager.Player);
        }
    }
}

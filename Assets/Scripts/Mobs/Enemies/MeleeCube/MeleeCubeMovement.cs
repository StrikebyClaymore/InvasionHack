using System;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.MeleeCube
{
    public class MeleeCubeMovement : EnemyMovement
    {
        protected override void Start()
        {
            base.Start();
            SetTarget(GameManager.Player);
        }
    }
}

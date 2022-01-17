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
            SetTarget(transform.root.GetComponent<GameManager>().player);
        }
    }
}

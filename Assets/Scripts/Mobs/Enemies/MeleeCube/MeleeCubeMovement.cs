using System;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.MeleeCube
{
    public class MeleeCubeMovement : EnemyMovement
    {
        private void Start()
        {
            GetComponentInChildren<MobsDetecter>().Initialize(this, Attack);
        }
    }
}

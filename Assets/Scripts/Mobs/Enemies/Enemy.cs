using System;
using Assets.Scripts.Factory;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies
{
	public class Enemy : Mob
	{
		private EnemyFactory _originFactory;
		public EnemyFactory OriginFactory
		{
			get => _originFactory;
			set => _originFactory = value;
		}
			
		public void Spawn(Vector3 point)
		{
			transform.position = point;
		}

		public override void Die()
		{
			transform.parent.GetComponent<MobsManager>().UpdateEnemiesCounter();
			base.Die();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("EnemyBounds"))
			{
				Die();
			}
		}
	}
}

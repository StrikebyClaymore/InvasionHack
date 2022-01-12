using System;
using Assets.Scripts.Factory;
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

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Bounds"))
			{
				Die();
			}
		}
	}
}

using System;
using Assets.Scripts.Mobs.Player.Upgrades;
using UnityEngine;

namespace Assets.Scripts.Mobs.Player
{
	public class Player : Mob
	{
		private PlayerMovement _playerMovement;
		private PlayerAttack _playerAttack;

		protected override void Awake()
		{
			base.Awake();
			_playerMovement = GetComponent<PlayerMovement>();
			_playerAttack = GetComponent<PlayerAttack>();
		}

		public void ApplyUpgrades(UpgradeList upgradeList)
		{
			maxHp = (int) upgradeList.health.scale[GameData.Health];
			
			_playerMovement.ApplyUpgrades(upgradeList);
			_playerAttack.ApplyUpgrades(upgradeList);
		}
		
		public override void GetHit(int damage)
		{
			currentHp = Mathf.Max(currentHp - damage, 0);
			if (currentHp == 0)
			{
				currentHp = maxHp;
				
				Respawn();
				//Die();
			}
		}

		private void Respawn()
		{
			GetComponent<PlayerControl>().RespawnLockInput();
			Invoke(nameof(RespawnSetPosition), 0.1f);
		}

		private void RespawnSetPosition()
		{
			transform.position = Vector3.zero + new Vector3(0f, 5f, 0f);
		}

		public int GetGrade() => currentHp >= maxHp / 100 * 80 ? 1 : 0;

	}
}

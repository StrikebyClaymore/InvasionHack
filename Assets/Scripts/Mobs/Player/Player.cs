using UnityEngine;

namespace Assets.Scripts.Mobs.Player
{
	public class Player : Mob
	{
		public override void GetHit(int damage)
		{
			currentHp = Mathf.Max(currentHp - damage, 0);
			if (currentHp == 0)
			{
				currentHp = maxHp;
				transform.position = Vector3.zero + new Vector3(0f, 5f, 0f);
				//Die();
			}
		}
	}
}
